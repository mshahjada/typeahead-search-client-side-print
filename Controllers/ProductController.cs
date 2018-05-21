using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EFApp.Models;
using EFApp.Service;
using System.Threading.Tasks;
using System.Web.Mvc;
using EFApp.Entity;

namespace EFApp.Controllers
{
    public class ProductController : Controller
    {

        protected IProductService service { get; set; }

        public ProductController(IProductService pservice)
        {
            this.service = pservice;
        }

        public async Task<JsonResult> GetAll()
        {
            var result = await this.service.GetAll();
            return new JsonResult() { Data = result, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public JsonResult Get(int id)
        {

            var result = new Product();

            using (var db = new TestDBEntities1())
            {
                result = db.Products.First();
            }

            return new JsonResult() { Data = result, JsonRequestBehavior= JsonRequestBehavior.AllowGet };

        }

        public JsonResult Gets()
       {
            var result = new List<Product>();

            using (var db = new TestDBEntities1())
            {
                result = db.Products.ToList();
            }
            return new JsonResult() { Data = result, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }


    }
}
