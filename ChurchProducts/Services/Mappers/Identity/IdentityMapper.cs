
using AutoMapper;
using DbModels.Identity;
using DbModels.Model;
using DbModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Mappers.Identity
{
    public static class IdentityMapper
    {
        public static Mapper Mapper = new Mapper( new MapperConfiguration( map => {
            map.CreateMap<Product, ProductModel>();
            map.CreateMap<ProductModel, Product>();
        }));


    }
}
