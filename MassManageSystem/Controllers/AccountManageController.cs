using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MassManageSystem.Controllers
{
    public class AccountManageController : Controller
    {
        // GET: AccountManage
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AccountManageIndex()
        {
            return View();
        }
    }
}