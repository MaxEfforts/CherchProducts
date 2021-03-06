using DbModels.ModelBases;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DisplayName("اسم المنتج")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "يجب ادخال سعر المنتج")]
        [DisplayName("السعر")]
        public double ProductPrice { get; set; }
        public string ProductImgPath { get; set; }

    }
}
