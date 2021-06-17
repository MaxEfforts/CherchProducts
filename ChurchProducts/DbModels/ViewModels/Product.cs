using DbModels.ModelBases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbModels.ViewModels
{
    public class Product : AbstractTableBase
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "يجب ادخال المنتج")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "يجب ادخال سعر المنتج")]
        public double ProductPrice { get; set; }
    }
}
