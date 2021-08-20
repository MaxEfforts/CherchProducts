using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbModels.ModelBases
{
    public abstract class AbstractTableBase : ITablesBase
    {
        [DisplayName("التاريخ")]
        public DateTime AddedOn { get; set; }
        public string AddedBy { get; set; }
        public DateTime DeletedOn { get; set; }
        public string DeletedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
    }
}
