using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MassManageSystem.Models;

namespace MassManageSystem.Controllers
{
    public class MillManageController : Controller
    {
        Models.MassManageSystemEntities db = new MassManageSystemEntities();

        // GET: MillManage
        public ActionResult MillManageIndex() 
        {
            return View();
        }

        // call today mill modal
        [HttpGet]
        public ActionResult AddTodayMill()
        {
            return View();
        }

        // partial view for add mill
        public ActionResult MillAdd()
        {
            return PartialView("MillAdd");
        }

        // get memberinfo 
        [HttpGet]
        public ActionResult GetMemberInfo()
        {
            List<MemberInfoTbl> memberinfo = db.MemberInfoTbls.Where(x=>x.Status==true).ToList();
            return Json(memberinfo, JsonRequestBehavior.AllowGet);
        }

        // Insert millinformation 
        [HttpPost]
       // [ValidateAntiForgeryToken]
        public ActionResult PostMillInfo(MillInfoTbl millInfoTbl)
        {
            if (ModelState.IsValid)
            {
                db.MillInfoTbls.Add(millInfoTbl);
                db.SaveChanges();
                return Json(true);
            }
            return View(millInfoTbl);
        }

    


    }
}