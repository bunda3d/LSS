using LSS.Server.Helpers;
using LSS.Server;
using LSS.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;

namespace LSS.Server.Controllers
{

  [ApiController]
  [Route("api/[controller]")]
  public class ProductsController : ControllerBase
  {
    private readonly ApplicationDbContext context;
    private readonly IFileStorageService fileStorageService;
    private string containerName = "img/product";

    public ProductsController(ApplicationDbContext context, IFileStorageService fileStorageService)
    {
      this.context = context;
      this.fileStorageService = fileStorageService;
    }


    [HttpPost]
    public async Task<ActionResult<int>> Post(Product product)
    {
      if (!string.IsNullOrWhiteSpace(product.Poster))
      {
        var productPicture = Convert.FromBase64String(product.Poster);
        product.Poster = await fileStorageService.SaveFile(productPicture, "jpg", containerName);
      }


      //could not get looping through ProductsPeople
      //work to order Product Roles. Got a bizarre reason about indexing
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
