using DbModels.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChurchProducts.Model
{
    public class ProductModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "يجب ادخال المنتج")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "يجب ادخال سعر المنتج")]
        public double ProductPrice { get; set; }
        public List<Product> productsList { get; set; }
    }
}
