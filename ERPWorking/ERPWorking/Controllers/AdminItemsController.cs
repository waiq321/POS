using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HospitalApp.Core;
using HospitalApp.Infrastructure;
using HospitalApp.Core.HospitalAdminViewModels;

namespace HospitalDemoWorking.Controllers
{
    public class AdminItemsController : Controller
    {
       
        //
        // GET: /AdminItems/
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetItemCatageory()
        {
            ItemCatageoryViewModel viewModel = new ItemCatageoryViewModel();
            ItemCatageoryRepository repository = new ItemCatageoryRepository();

            viewModel.getItemCatageories=repository.getItemCatageories();                        
            return Json(new { data = viewModel.getItemCatageories }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult AddorEdit(int id=0)
        {
                ItemCatageoryViewModel viewmodel = new ItemCatageoryViewModel();
                ItemTypeRepository _itemytype = new ItemTypeRepository();
                viewmodel._itemTypes=_itemytype.getItemType();
                return View(viewmodel);
        }


        [HttpPost]
        public ActionResult AddorEdit(ItemCatageoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                ItemCatageory catageory = new ItemCatageory();
                catageory.CatageoryName = model.Name;
                catageory.ItemTypeID = 1;

                ItemCatageoryRepository rep = new ItemCatageoryRepository();
                rep.Add(catageory);
                return Json(new { success = true, message = "Save Successfully" }, JsonRequestBehavior.AllowGet);
            }
            else
                return View(model);
        }
	}
}