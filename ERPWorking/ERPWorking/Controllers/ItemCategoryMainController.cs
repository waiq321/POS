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
    
    public class ItemCategoryMainController : Controller
    {
        
         ItemCategoryMainRepository rep = new ItemCategoryMainRepository();
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
                ItemCategoryMainViewModel model = new ItemCategoryMainViewModel();                
                return View(model);
            }
            else
            {
                ItemCategoryMainViewModel model = new ItemCategoryMainViewModel();
                ItemCategoryMainRepository repository = new ItemCategoryMainRepository();
                model = repository.GetCategoryByID(id);
                return View(model);
            }
        }

        [HttpPost]
        public JsonResult AddCategory(ItemCategoryMain model)
        {
            ItemCategoryMain ICM = new ItemCategoryMain();
            if (model != null && model.CategoryId == 0)
            {
                ICM.CategoryId = model.CategoryId;
                ICM.CategoryName = model.CategoryName;
                ICM.Abb = model.Abb;
                ICM.BranchId = 4;
                ICM.Active = true;
                rep.Add(ICM);
                return Json(new { success = true, message = "Save Successfully" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                ICM.CategoryId = model.CategoryId;
                ICM.CategoryName = model.CategoryName;
                ICM.Abb = model.Abb;
                ICM.BranchId = 4;
                ICM.Active = true;
                rep.Update(ICM);

                return Json(new { success = true, message = "Update Successfully" }, JsonRequestBehavior.AllowGet);
            }
            return null;
        }


        public JsonResult DeletCategory(int id)
        {
            rep.Remove(id);
            return Json(new { success = true, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
        }

    }
}
