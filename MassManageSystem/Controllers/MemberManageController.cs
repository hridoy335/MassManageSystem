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

        //public ActionResult PartialAddMemberinfo()
        //{
        //    return PartialView("PartialAddMemberinfo");
        //}
    }
}