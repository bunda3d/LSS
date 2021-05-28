using LSS.Server.Helpers;
using LSS.Server;
using LSS.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using LSS.Shared.DTOs;
using Microsoft.EntityFrameworkCore;

namespace LSS.Server.Controllers
{

  [ApiController]
  [Route("api/[controller]")]
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
    public async Task<ActionResult<IndexPageDTO>> Get()
    {
      var limit = 6;
      var todaysDate = DateTime.Today;

      var productIsFeatured = await context.Products
        .Where(x => x.IsFeatured == true)
        .Take(limit).OrderByDescending(x => x.SellStartDate)
        .ToListAsync();      

      var productIsNewRelease = await context.Products
        .Where(x => x.SellStartDate <= todaysDate.AddDays(50))
        .Take(limit).OrderByDescending(x => x.SellStartDate)
        .ToListAsync();

      var productIsTrending = await context.Products 
        .Where(x => x.IsTrending == true || 
                    x.QtyInStock / x.QtyOrderedOnPO < 0.25)
        .Take(limit).OrderByDescending(x => x.SellStartDate)
        .ToListAsync();

      var productIsOnSale = await context.Products
        .Where(x => x.IsOnSale == true)
        .Take(limit).OrderByDescending(x => x.SellStartDate)
        .ToListAsync();

      var productIsOnClearance = await context.Products
        .Where(x => x.IsOnClearance == true ||
                    x.Price / x.UnitCostOnPO < 0.75M)
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
          product.ProductsPeople[i].Role = i + 1;
        }
      }

      context.Add(product);
      await context.SaveChangesAsync();
      
      return product.Id;
      
    }

  }
}
