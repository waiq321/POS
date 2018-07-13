using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalApp.Core
{
   public  class ItemCatageory
    {
        public int ID { get; set; }
        public string CatageoryName { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<StoreItems> StoreItems { get; set; }

        [ForeignKey("ItemType")]
        public int? ItemTypeID { get; set; }
        public virtual ItemType ItemType { get; set; }
    }
}
