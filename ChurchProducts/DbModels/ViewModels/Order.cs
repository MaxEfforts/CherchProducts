using DbModels.Identity;
using DbModels.ModelBases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbModels.ViewModels
{
    public class Order : AbstractTableBase
    {
        public int Id { get; set; }
        [Required]
        [ForeignKey("applicationUser")]
        public string UserIDFK { get; set; }
        public ApplicationUser applicationUser { get; set; }
        [DisplayName("الاسم")]
        [Required]
        public string UserName { get; set; }

        [DisplayName("تم التسليم")]
        public bool IsDeleverd { get; set; }


    }
}
