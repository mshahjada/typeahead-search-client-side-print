using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EFApp.Models;
using EFApp.Entity;
using System.Threading.Tasks;
using System.Data.Entity;
using AutoMapper;

namespace EFApp.Service
{
    public class ProductService : IProductService
    {
        protected TestDBEntities1 DBCtx { get; set; }
        protected IMapper mapper { get; set; }

        public ProductService(IMapper map)
        {
            DBCtx = new TestDBEntities1();
            mapper = map;
        }
        public async Task<List<ProductModel>> GetAll()
        {
            var result = await DBCtx.Products.ToListAsync();

            //var model = result.Select(x => new ProductModel
            //{
            //    Id = x.Id,
            //    Name = x.Name,
            //    Category = x.Category
            //}).ToList();

            var model = Mapper.Map<List<ProductModel>>(result);


            return model;
        }
    }
}