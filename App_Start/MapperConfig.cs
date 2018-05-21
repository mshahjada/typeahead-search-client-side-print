using AutoMapper;
using EFApp.Entity;
using EFApp.Models;

namespace EFApp
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            #region setup
            CreateMap<Product, ProductModel>();
            #endregion
        }
    }
}
