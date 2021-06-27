using DbModels.ViewModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChurchProducts.Model
{
    public class ProductModel:Product
    {
        
        public IFormFile photoUrl { get; set; }
    }
}
