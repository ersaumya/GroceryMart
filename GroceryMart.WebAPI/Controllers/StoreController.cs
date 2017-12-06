using AutoMapper;
using GroceryMart.BAL;
using GroceryMart.DomainModels.Dtos;
using GroceryMart.DomainModels.Entities;
using GroceryMart.WebAPI.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace GroceryMart.WebAPI.Controllers
{
    [EnableCors("*","*","*")]
    //[CustomAuthorizeFilter(Roles = "User")]
    public class StoreController : ApiController
    {
        
        IUnitOfWork _uow;
        public StoreController(IUnitOfWork uow)
        {
            _uow = uow;
        }
        [HttpGet]
        public IEnumerable<ProductDto> GetProducts()
        {
            return _uow.ProductRepo.GetAll().Select(Mapper.Map<Product,ProductDto>);
        }
        [HttpPost]
        [CustomAuthorizeFilter(Roles = "User")]
        
        public int SaveCart(Cart model)
        {
            return _uow.OrderRepo.SaveCart(model);
        }
    }
}
