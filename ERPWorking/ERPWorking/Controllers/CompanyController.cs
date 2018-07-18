using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERPApp.Core;
using ERPApp.Infrastructure;
using ERPApp.Infrastructure.ViewModels;
using ERPApp.Infrastructure.ERPAdminRepository;

namespace ERPWorking.Controllers
{
    public class CompanyController : Controller
    {
        CompanyRepository rep = new CompanyRepository();
        // GET: Company
        public ActionResult Index()
        {
            return View();
        }


        public JsonResult getata()
        {        
            return Json(new { data = rep.getCompanies() }, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ActionResult AddCompanies(int id=0)
        {
            if (id ==0)
            {
                CompanyViewModel model = new CompanyViewModel();                
                CommonRepository objCommonRepository = new CommonRepository();
                model.Cities = objCommonRepository.GetCities(true,null,"Select");
                return View(model);
            }
            else
            {
                CompanyViewModel model = new CompanyViewModel();
                CompanyRepository repository = new CompanyRepository();
                model = repository.GetCompanyByID(id);
                return View(model);
            }            
        }

        [HttpPost]
        public JsonResult AddCompanies(CompanyViewModel model)
        {
            Company _company = new Company();
            if (model != null && model.CompanyID==0)
            {
                _company.Address = model.Address;
                _company.CityId = model.CityID;
                _company.CompanyName = model.CompanyName;
                _company.Active = true;
                _company.WebsiteURL = model.WebsiteUrl;
                _company.Phone = model.PhoneNo;

                rep.Add(_company);
                return Json(new { success = true, message = "Save Successfully" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                _company.Address = model.Address;
                _company.CityId = model.CityID;
                _company.CompanyName = model.CompanyName;
                _company.Active = true;
                _company.WebsiteURL = model.WebsiteUrl;
                _company.Phone = model.PhoneNo;
                _company.CompanyId = model.CompanyID;
                rep.Update(_company);

                return Json(new { success = true, message = "Update Successfully" }, JsonRequestBehavior.AllowGet);
            }
            return null;            
        }


        public JsonResult DeletCompanies(int id)
        {
            rep.Remove(id);
            return Json(new { success = true, message = "Delet Successfully" }, JsonRequestBehavior.AllowGet);
        }

    }    
        
}