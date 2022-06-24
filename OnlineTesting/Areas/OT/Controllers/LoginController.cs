using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTesting.Models;

namespace OnlineTesting.Areas.OT.Views.Login
{
    public class LoginController : Controller
    {
        // GET: OT/Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            var id = collection["user_id"];
            var pw = collection["user_pw"];
            // id bat dau bang "S"
            if (BLL.Instance.TakeStudentfromLogin(id,pw)!=null&&id.StartsWith("S"))
            {
                Session["user"]= (Student)BLL.Instance.TakeStudentfromLogin(id,pw);
                return RedirectToAction("Index", "Student");
            }
            else
            {
                ViewData["Thongbao"] = "User_id or User_pw is not right.";
            }
            return View();
        }
    }
}