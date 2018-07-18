using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ERPApp.Infrastructure.ViewModels
{
  public  class CompanyViewModel
    {
        public int CompanyID { get; set; }

        [Required(ErrorMessage ="Company Name is Required")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "Phone No. is Required")]
        public string PhoneNo { get; set; }

        
        public string WebsiteUrl { get; set; }

        [Required(ErrorMessage = "Address is Required")]
        public string Address { get; set; }



        public string CityName { get; set; }

        [Required(ErrorMessage = "City is Required")]
        public int CityID { get; set; }

        public IEnumerable<SelectListItem> Cities { get; set; }
    }
}
