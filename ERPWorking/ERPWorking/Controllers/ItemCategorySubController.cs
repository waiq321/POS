using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ERPApp.Core;
using ERPApp.Infrastructure;
using ERPApp.Infrastructure.ViewModels;
using ERPApp.Infrastructure.ERPAdminRepository;

namespace ERPWorking.Controllers
{
    
    public class ItemCategorySubController : Controller
    {
        
         ItemCategorySubRepository rep = new ItemCategorySubRepository();
        // GET: Company
        public ActionResult Index()
        {
            return View();
        }


        public JsonResult getata()
        {           
            return Json(new { data = rep.GetCategories() }, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ActionResult AddCategory(int id = 0)
        {
            if (id == 0)
            {
                ItemCategorySubViewModel model = new ItemCategorySubViewModel();
                CommonRepository objCommonRepository = new CommonRepository();
                model.Categories = objCommonRepository.GetMainCategories(false,null);

                return View(model);
            }
            else
            {
                ItemCategorySubViewModel model = new ItemCategorySubViewModel();
                ItemCategorySubRepository repository = new ItemCategorySubRepository();               
                model = repository.GetCategoryByID(id);                
                return View(model);
            }
        }

        [HttpPost]
        public JsonResult AddCategory(ItemCategorySub model)
        {
            ItemCategorySub ICS = new ItemCategorySub();
            if (model != null && model.SubCategoryId == 0)
            {
                ICS.SubCategoryId = model.SubCategoryId;
                ICS.SubCategoryName = model.SubCategoryName;
                ICS.CategoryId = model.CategoryId;
                ICS.Abb = model.Abb;               
                ICS.Active = true;
                rep.Add(ICS);
                return Json(new { success = true, message = "Save Successfully" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                ICS.SubCategoryId = model.SubCategoryId;
                ICS.SubCategoryName = model.SubCategoryName;
                ICS.CategoryId = model.CategoryId;
                ICS.Abb = model.Abb;
                ICS.Active = true;

                rep.Update(ICS);

                return Json(new { success = true, message = "Update Successfully" }, JsonRequestBehavior.AllowGet);
            }
            
        }


        public JsonResult DeletCategory(int id)
        {
            rep.Remove(id);
            return Json(new { success = true, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
        }

    }
}
