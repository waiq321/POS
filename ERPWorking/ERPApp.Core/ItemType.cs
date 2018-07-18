using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPApp.Core
{
   public class ItemType
    {
        public int ID { get; set; }
        public string TypeName { get; set; }

        public virtual ICollection<StoreItems> StoreItems { get; set; }
        public virtual ICollection<ItemManufacturer> ItemManufacturer { get; set; }
        public virtual ICollection<ItemCatageory> ItemCatageory { get; set; }

    }
}
