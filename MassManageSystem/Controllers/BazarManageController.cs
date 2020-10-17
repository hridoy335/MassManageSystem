using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MassManageSystem.Models;

namespace MassManageSystem.Controllers
{
    public class BazarManageController : Controller
    {
        Models.MassManageSystemEntities db = new MassManageSystemEntities();
        // GET: BazarManage
        public ActionResult Index()
        {
            return View();
        }

        // Insert Bazar Information
        [HttpPost]
        public ActionResult PostBazarInfo(BazarInfoTbl bazarInfoTbl)
        {
            if (ModelState.IsValid)
            {
                db.BazarInfoTbls.Add(bazarInfoTbl);
                db.SaveChanges();
                return Json(1);
            }
            return View(bazarInfoTbl);
        }
    }
}