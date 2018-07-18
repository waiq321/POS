using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ERPApp.Infrastructure.ViewModels
{
  public  class ItemCategoryMainViewModel
    {
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Category Name is Required")]
        public string CategoryName { get; set; }

        [Required(ErrorMessage = "Abb is Required")]
        public string Abb { get; set; }

       
    }
}
