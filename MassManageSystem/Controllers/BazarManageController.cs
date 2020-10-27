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

        public ActionResult BazarManageIndex()
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

        [HttpGet]
        public JsonResult GetBazarinfo()
        {
            Models.DataLayer.GetBazarInfo getBazarInfo = new Models.DataLayer.GetBazarInfo();
            List<BazarInfoTbl> bazarInfoTbls = getBazarInfo.bazarInfoTbls.ToList();
            return Json(bazarInfoTbls, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult PartialEditBazar(int? BazarInfoId)  
        {
            if (BazarInfoId == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            BazarInfoTbl bazarInfoTbl = db.BazarInfoTbls.Find(BazarInfoId);
            if (bazarInfoTbl == null)
            {
                return HttpNotFound();
            } 
            return View(bazarInfoTbl);
        }

        [HttpPost]
        public ActionResult PartialEditBazar(BazarInfoTbl bazarInfoTbl) 
        {
            if (ModelState.IsValid)
            {
                var date = bazarInfoTbl.Date;
                var bazarid = bazarInfoTbl.BazarInfoId;
                var matchdata = db.BazarInfoTbls.Where(x => x.BazarInfoId == bazarid && x.Date == date).FirstOrDefault();
                if (matchdata == null)
                {
                    db.Entry(bazarInfoTbl).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return Json(1);
                }
                
            }
            return View(bazarInfoTbl);
        }



    }
}