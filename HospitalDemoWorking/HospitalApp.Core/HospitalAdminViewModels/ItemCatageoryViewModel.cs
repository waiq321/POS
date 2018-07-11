using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace HospitalApp.Core.HospitalAdminViewModels
{
    public class ItemCatageoryViewModel
    {
        public int? ItemCatageoryID { get; set; }

        [Required(ErrorMessage="This Field is Required")]
        public string Name { get; set; }

        
        public string ItemTypeName { get; set; }
        public int? ItemTypeID { get; set; }

        public virtual IEnumerable<SelectListItem> _itemTypes { get; set; }

        public virtual IEnumerable<ItemCatageoryViewModel> getItemCatageories { get; set; }

    }
}
