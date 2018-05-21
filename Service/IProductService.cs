using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EFApp.Models;
using System.Threading.Tasks;

namespace EFApp.Service
{
    public interface IProductService
    {
        Task<List<ProductModel>> GetAll();
    }
}