using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MassManageSystem.Models;

namespace MassManageSystem.Controllers
{
    public class MemberManageController : Controller
    {
        Models.MassManageSystemEntities db = new MassManageSystemEntities();
        // GET: MemberManage
        public ActionResult Index()
        {
            return View();
        }

        // get memberinfo 
        [HttpGet]
        public ActionResult GetMemberInfo()
        {

            List<MemberInfoTbl> memberinfo = db.MemberInfoTbls.ToList();
            return Json(memberinfo, JsonRequestBehavior.AllowGet);

        }


        // add memberinfo 
        [HttpGet]
        public ActionResult AddMemberInfo()
        {
            return PartialView("PartialAddMemberinfo");
        }
        [HttpPost]
        public ActionResult AddMemberInfo(MemberInfoTbl memberInfoTbl)
        {
            int er = 0;
            if (memberInfoTbl.Name == null)
            {
                er++;
                //  return Json("Not Insert");
            }
            if (memberInfoTbl.Contact == null)
            {
                er++;
                // return Json("Not Insert");
            }
            if (memberInfoTbl.Email == null)
            {
                er++;
                // return Json("Not Insert");
            }
            if (memberInfoTbl.Image == null)
            {
                er++;
                //return Json("Not Insert");
            }
            if (memberInfoTbl.ParentContact == null)
            {
                er++;
                // return Json("Not Insert");
            }
            if (memberInfoTbl.UserName == null)
            {
                er++;
                // return Json("Not Insert");
            }
            if (memberInfoTbl.Password == null)
            {
                er++;
                //  return Json("Not Insert");
            }

            if (er > 0)
            {
                return Json(false);
            }

            if (ModelState.IsValid)
            {
                db.MemberInfoTbls.Add(memberInfoTbl);
                db.SaveChanges();
                return Json(true);
            }
            return View(memberInfoTbl);
         
        }

        //public ActionResult PartialAddMemberinfo()
        //{
        //    return PartialView("PartialAddMemberinfo");
        //}

        public ActionResult addmember()
        {
            return View();
        }

        // AddEditMemberInfo
        [HttpGet]
        public ActionResult PartialAddEditMemberInfo(int? MemberInfoId)
        { 
            if (MemberInfoId == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            MemberInfoTbl memberInfoTbl = db.MemberInfoTbls.Find(MemberInfoId);
            if (memberInfoTbl==null)
            {
                return HttpNotFound();
            }
            return View(memberInfoTbl);
        }

        [HttpPost]
        public ActionResult PartialAddEditMemberInfo(MemberInfoTbl memberInfoTbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(memberInfoTbl).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return Json(true);
            }
            return Json(false);
        }
    }
}