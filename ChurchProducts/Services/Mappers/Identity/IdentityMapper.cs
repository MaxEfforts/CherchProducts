
using AutoMapper;
using DbModels.Identity;
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
          //  map.CreateMap<ApplicationUser, RegisterModel>().ReverseMap();
        }));


    }
}
