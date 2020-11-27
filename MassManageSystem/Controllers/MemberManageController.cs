using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MassManageSystem.Models;
using System.IO;

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
        public JsonResult GetMemberInfo()
        {

            GetMembers dal = new GetMembers();
            List<MemberInfoTbl> GelAllMemberInfo = dal.MemberInfoTbl.ToList();
            return Json(GelAllMemberInfo, JsonRequestBehavior.AllowGet); 

        }


        // add memberinfo 
        [HttpGet]
        public ActionResult AddMemberInfo()
        {
            return PartialView("PartialAddMemberinfo");
        }
        [HttpPost]
        public ActionResult AddMemberInfo(MemberInfoTbl memberInfoTbl, HttpPostedFileBase Imagefile) 
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
            //if (memberInfoTbl.Image == null)
            //{
            //    er++;
            //    //return Json("Not Insert");
            //}
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

            var image = memberInfoTbl.Image;
            string path = UploadImage(Imagefile); 
            if (path.Equals("-1"))
            {
                return View(image);
            }
            //MemberInfoTbl memberInfoTbl1 = new MemberInfoTbl();
            memberInfoTbl.Image = path;
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

        public string UploadImage(HttpPostedFileBase file)
        {
            Random ran = new Random();
            string path = "-1";
            int random = ran.Next();
            if (file != null && file.ContentLength > 0)
            {
                string extention = Path.GetExtension(file.FileName);
                if (extention.ToLower().Equals(".jpg") || extention.ToUpper().Equals(".JPG") || extention.ToLower().Equals(".png"))
                {
                    try
                    {
                        path = Path.Combine(Server.MapPath("~/Image/MemberImage/"), random + Path.GetFileName(file.FileName));
                        file.SaveAs(path);
                        path = "~/Image/MemberImage/" + random + Path.GetFileName(file.FileName);
                    }
                    catch (Exception ex)
                    {
                        path = "-1";
                    }

                }
                else
                {
                    Response.Write("<script>alrt('Only jpg or JPG or png formate'); <script>");
                }

            }
            else
            {
                Response.Write("<script>alrt('Please select file ..'); <script>");
                path = "-1";

            }


            return path;
        }
    }
}