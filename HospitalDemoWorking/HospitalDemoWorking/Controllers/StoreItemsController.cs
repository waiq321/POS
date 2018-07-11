using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HospitalApp.Infrastructure;
using HospitalApp.Core;

namespace HospitalDemoWorking.Controllers
{
    public class StoreItemsController : Controller
    {
        //
        // GET: /StoreItems/
        public ActionResult Index()
        {
            StoreContext c = new StoreContext();            
            return View();
        }

        
	}
}