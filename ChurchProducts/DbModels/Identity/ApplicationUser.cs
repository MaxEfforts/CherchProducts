
using DbModels.ModelBases;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbModels.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public bool IsServant { get; set; }
        public string UserSecretKey { get; set; }
        public DateTime AddedOn { get; set; }
        public string AddedBy { get; set; }
        public DateTime DeletedOn { get; set; }
        public string DeletedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        [NotMapped]
        public string NewUserPassword { get; set; }
    }
}
