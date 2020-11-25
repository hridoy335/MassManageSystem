using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MassManageSystem.Models;
using MassManageSystem.DTO;

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
        public JsonResult GetMemberInfo()
        {

            GetMembers dal = new GetMembers();
            List<MemberInfoTbl> Membersforbazar = dal.MemberInfoTblforBazar.ToList();
            return Json(Membersforbazar, JsonRequestBehavior.AllowGet);
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
        // get member information for bazar and mill
        public JsonResult GetMillThisMonth()
        {

            Models.DataLayer.GetMillThisMonthinfo dal = new Models.DataLayer.GetMillThisMonthinfo();
            List<MillDTO> MillInfoTbl = dal.MillInfoTbl();
            return Json(MillInfoTbl, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public ActionResult PartialEditMill(int? MillInfoId) 
        {
            if (MillInfoId == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            MillInfoTbl millInfoTbl = db.MillInfoTbls.Find(MillInfoId);
            if (millInfoTbl == null)
            {
                return HttpNotFound();
            }
            return View(millInfoTbl);
            
        }

        [HttpPost]
        public ActionResult PartialEditMill(MillInfoTbl millInfoTbl)
        {
            if (ModelState.IsValid)
            {
                var date = millInfoTbl.Date;
                var millid = millInfoTbl.MillInfoId;
                var AlreadyDatahave = db.MillInfoTbls.Where(x=>x.Date==date && x.MillInfoId==millid).FirstOrDefault();
                if (AlreadyDatahave == null)
                {
                    db.Entry(millInfoTbl).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return Json(1);
                }
            }
            return Json(0);
        }





    }
}