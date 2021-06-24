using AutoMapper;
using LSS.Server.Helpers;
using LSS.Shared.DTOs;
using LSS.Shared.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LSS.Server.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
  public class ProductsController : ControllerBase
  {
    private readonly ApplicationDbContext context;
    private readonly IFileStorageService fileStorageService;
    private readonly string containerName = "products";
    private readonly string fileExtension = ".jpg";
    private readonly IMapper mapper;

    public ProductsController(ApplicationDbContext context,
      IFileStorageService fileStorageService,
      IMapper mapper)
    {
      this.context = context;
      this.fileStorageService = fileStorageService;
      this.mapper = mapper;
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<ActionResult<IndexPageDTO>> Get()
    {
      //limit = number of products shown for ea filter on page
      var limit = 12;
      DateTime todaysDate = DateTime.Today;
      DateTime newReleaseWindowStart = todaysDate.AddDays(-50);

      //product is featured if flagged, appears at top of page
      var productIsFeatured = await context.Products
        .Where(x => x.IsFeatured == true)
        .Take(limit).OrderByDescending(x => x.SellStartDate)
        .ToListAsync();

      //product considered new release if orig listing date was in last 50 days
      var productIsNewRelease = await context.Products
        .Where(x => x.SellStartDate >= newReleaseWindowStart && x.SellStartDate <= todaysDate)
        .Take(limit).OrderByDescending(x => x.SellStartDate)
        .ToListAsync();

      //product is trending if flagged or stock unit qty (25% or less) of orig. PO unit qty
      var productIsTrending = await context.Products
        .Where(x => x.IsTrending == true ||
                  (((x.QtyInStock == 0 ? 0.01M : x.QtyInStock) / (x.QtyOrderedOnPO == 0 ? 0.01M : x.QtyOrderedOnPO) * 1M) < 0.26M))
        .Take(limit).OrderByDescending(x => x.SellStartDate)
        .ToListAsync();

      //product is on sale if flagged or is up-to 25% off PO's unit cost (inverted > 0.74)
      var productIsOnSale = await context.Products
        .Where(x => x.IsOnSale == true ||
                   ((((x.Price == 0 ? 0.01M : x.Price) / (x.UnitCostOnPO == 0 ? 0.01M : x.UnitCostOnPO)) > 0.74M) ? true : false))
        .Take(limit).OrderByDescending(x => x.SellStartDate)
        .ToListAsync();

      //product is on clearance if flagged or is over 25% off PO's unit cost (inverted < 0.75)
      var productIsOnClearance = await context.Products
        .Where(x => x.IsOnClearance == true ||
                  (((x.Price == 0 ? 0.01M : x.Price) / (x.UnitCostOnPO == 0 ? 0.01M : x.UnitCostOnPO)) < 0.75M))
        .Take(limit).OrderByDescending(x => x.SellStartDate)
        .ToListAsync();

      var response = new IndexPageDTO();
      response.Featured = productIsFeatured;
      response.NewRelease = productIsNewRelease;
      response.Trending = productIsTrending;
      response.OnSale = productIsOnSale;
      response.OnClearance = productIsOnClearance;

      return response;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<DetailsProductDTO>> Get(int id)
    {
      var product = await context.Products.Where(x => x.Id == id)
        .Include(x => x.ProductsCategories).ThenInclude(x => x.Category)
        .Include(x => x.ProductsPeople).ThenInclude(x => x.Person)
        .FirstOrDefaultAsync();

      if (product == null) { return NotFound(); }

      product.ProductsPeople = product.ProductsPeople.OrderBy(x => x.Order).ToList();

      var model = new DetailsProductDTO();
      model.Product = product;
      model.Categories = product.ProductsCategories.Select(x => x.Category).ToList();
      model.People = product.ProductsPeople.Select(x =>
        new Person
        {
          NameFirst = x.Person.NameFirst,
          NameLast = x.Person.NameLast,
          Photo = x.Person.Photo,
          Role = x.Role,
          Id = x.PersonId
        }).ToList();

      return model;
    }

    [HttpGet("update/{id}")]
    public async Task<ActionResult<ProductUpdateDTO>> PutGet(int id)
    {
      var productActionResult = await Get(id);
      if (productActionResult.Result is NotFoundResult) { return NotFound(); }

      var productDetailDTO = productActionResult.Value;
      var selectedCategoriesIds = productDetailDTO.Categories
        .Select(x => x.Id)
        .ToList();
      var notSelectedCategories = await context.Categories
        .Where(x => !selectedCategoriesIds.Contains(x.Id))
        .ToListAsync();

      var model = new ProductUpdateDTO();

      model.Product = productDetailDTO.Product;
      model.SelectedCategories = productDetailDTO.Categories;
      model.NotSelectedCategories = notSelectedCategories;
      model.People = productDetailDTO.People;

      return model;
    }

    [HttpPut]
    public async Task<ActionResult> Put(Product product)
    {
      //productDB = same product, but from database
      var productDB = await context.Products.FirstOrDefaultAsync(x => x.Id == product.Id);

      if (productDB == null) { return NotFound(); }

      productDB = mapper.Map(product, productDB);

      //so as not to replace image every edit--only when it's changed
      if (!string.IsNullOrWhiteSpace(product.Poster))
      {
        var productPicture = Convert.FromBase64String(product.Poster);
        productDB.Poster = await fileStorageService.EditFile(productPicture,
          fileExtension, containerName, productDB.Poster);
      }

      //when updating Product: Just delete Products and People info and re add
      await context.Database.ExecuteSqlInterpolatedAsync(
        $"DELETE FROM ProductsPeople where ProductId = {product.Id}; DELETE FROM ProductsCategories where ProductId = {product.Id}");

      if (product.ProductsPeople != null)
      {
        for (int i = 0; i < product.ProductsPeople.Count; i++)
        {
          product.ProductsPeople[i].Order = i + 1;
        }
      }

      productDB.ProductsPeople = product.ProductsPeople;
      productDB.ProductsCategories = product.ProductsCategories;

      await context.SaveChangesAsync();
      return NoContent();
    }

    [HttpPost]
    public async Task<ActionResult<int>> Post(Product product)
    {
      if (!string.IsNullOrWhiteSpace(product.Poster))
      {
        var productPicture = Convert.FromBase64String(product.Poster);
        product.Poster = await fileStorageService
          .SaveFile(productPicture, fileExtension, containerName);
      }

      if (product.ProductsPeople != null)
      {
        //var productsPeople = (product.ProductsPeople).AsEnumerable().ToList();
        for (int i = 0; i < product.ProductsPeople.Count; i++)
        {
          product.ProductsPeople[i].Order = i + 1;
        }
      }

      context.Add(product);
      await context.SaveChangesAsync();

      return product.Id;
    }

    [HttpPost("filter")]
    [AllowAnonymous]
    public async Task<ActionResult<List<Product>>> Filter(ProductFilterDTO productFilterDTO)
    {
      var productsQueryable = context.Products.AsQueryable();

      if (!string.IsNullOrWhiteSpace(productFilterDTO.Title))
      {
        productsQueryable = productsQueryable
          .Where(x => x.Title.Contains(productFilterDTO.Title));
      }
      if (productFilterDTO.IsInStock)
      {
        productsQueryable = productsQueryable.Where(x => x.QtyInStock > 0);
      }
      if (productFilterDTO.IsTrending)
      {
        productsQueryable = productsQueryable.Where(x => x.IsTrending);
      }
      if (productFilterDTO.IsOnSale)
      {
        productsQueryable = productsQueryable.Where(x => x.IsOnSale);
      }
      if (productFilterDTO.IsOnClearance)
      {
        productsQueryable = productsQueryable.Where(x => x.IsOnClearance);
      }
      if (productFilterDTO.CategoryId != 0)
      {
        productsQueryable = productsQueryable
          .Where(x => x.ProductsCategories
          .Select(y => y.CategoryId)
          .Contains(productFilterDTO.CategoryId));
      }

      await HttpContext.InsertPaginationParametersInResponse(productsQueryable,
        productFilterDTO.RecordsPerPage);

      var products = await productsQueryable.Paginate(productFilterDTO.Pagination).ToListAsync();

      return products;
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
      var product = await context.Products.FirstOrDefaultAsync(x => x.Id == id);

      if (product == null)
      {
        return NotFound();
      }

      context.Remove(product);
      await context.SaveChangesAsync();
      return NoContent();
    }
  }
}