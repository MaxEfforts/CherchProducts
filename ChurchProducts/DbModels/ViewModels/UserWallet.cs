using DbModels.Identity;
using DbModels.ModelBases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbModels.ViewModels
{
    public class UserWallet: AbstractTableBase
    {
        public int Id { get; set; }
        public double Balance { get; set; }
        [ForeignKey("AppUser")]
        public string UserIDFK { get; set; }
        public ApplicationUser AppUser { get; set; }
    }
}
