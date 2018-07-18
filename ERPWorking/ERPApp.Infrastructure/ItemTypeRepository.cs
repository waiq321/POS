using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ERPApp.Infrastructure
{
 public   class ItemTypeRepository
    {
        public IEnumerable<SelectListItem> getItemType() {
            using (StoreContext context=new StoreContext())
            {
               List<SelectListItem> itemTypes= context.ItemType.Select(n => new SelectListItem { Text = n.TypeName, Value = n.ID.ToString() }).ToList();

               //var itemTypeTip = new SelectListItem() { Value = null, Text = "---Select Item Type" };

               //itemTypes.Insert(0, itemTypeTip);

               return new SelectList(itemTypes, "Value", "Text");
            }        
        }
    }
}
