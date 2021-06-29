using DbModels.ViewModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DbModels.Model
{
    public class ProductModel:Product
    {
        [NotMapped]
        public IFormFile photoUrl { get; set; }
    }
}
