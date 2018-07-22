using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ERPApp.Infrastructure.ERPAdminRepository
{
    public class CommonRepository
    {

        public IEnumerable<SelectListItem> GetCities(bool defaultRequired, int? id, string defaultText=null)
        {
            using (ERPContext context = new ERPContext())
            {
                List<SelectListItem> _items = context.City.Select(x => new SelectListItem { Text = x.CityName, Value = x.CityId.ToString() }).ToList();
                if (defaultRequired)
                {
                    var insertCaption = new SelectListItem() { Value = null, Text = defaultText };

                    _items.Insert(0, insertCaption);
                }
                return new SelectList(_items, "Value", "Text", id);
            }
        }
        public IEnumerable<SelectListItem> GetMainCategories(bool defaultRequired,int? id, string defaultText = null)
        {
            using (ERPContext context = new ERPContext())
            {
                List<SelectListItem> _items = context.ItemCategoryMain.Where(b => b.BranchId == 4 & b.Active).Select(b => new SelectListItem { Text = b.CategoryName.ToString(), Value = b.CategoryId.ToString() }).ToList();
                if (defaultRequired)
                {
                    var insertCaption = new SelectListItem() { Value = null, Text = defaultText };

                    _items.Insert(0, insertCaption);
                }
                return new SelectList(_items, "Value", "Text", id);
            }
        }
    }
}
