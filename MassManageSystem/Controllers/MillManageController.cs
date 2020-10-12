using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MassManageSystem.Controllers
{
    public class MillManageController : Controller
    {
        // GET: MillManage
        public ActionResult MillManageIndex() 
        {
            return View();
        }

        public ActionResult AddTodayMill()
        {
            return PartialView("MillAdd");
        }

        public ActionResult MillAdd()
        {
            return PartialView("MillAdd");
        }
    }
}