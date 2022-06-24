using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTesting.Models;

namespace OnlineTesting.Areas.OT.Controllers
{
    public class StudentController : Controller
    {
        // GET: OT/Student
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Logout()
        {
            Session["user"] = null;
            return RedirectToAction("Index", "Login");
        }
        public ActionResult Mission()
        {
            Session["test"] = null;
            return View();
        }
        public ActionResult TakeExam(string id)
        {
            Test t = BLL.Instance.TakeTestByTestID(id);
            return View(t);
        }
        public ActionResult OnTest(string id)
        {
            Session["time_start_test"] = DateTime.Now.ToString("MM-dd-yyyy hh:mm:ss");
            Test t = BLL.Instance.TakeTestByTestID(id);
            Session["test"] = t;
            return View(t);
        }
        public ActionResult History()
        {
            Session["test"] = null;
            return View();
        }
        public ActionResult HistoryDetail(string id)
        {
            Test_History th = BLL.Instance.TakeTestHistoryByID(id);
            return View(th);
        }
        [HttpPost]
        public ActionResult OnTest(FormCollection collection)
        {
            string time_start = Session["time_start_test"].ToString();
            Session["time_start_test"] = null;
            string time_finish = DateTime.Now.ToString("MM-dd-yyyy hh:mm:ss");
            Test t = (Test)Session["test"];
            Student st = (Student)Session["user"];
            int count = 1;
            string answer_record = "";
            foreach (Question_In_Test q in BLL.Instance.TakeQuestionInTest(t.Question_In_Test_ID))
            {
                var answer = collection[q.Question_In_Test_ID];
                answer_record = answer_record + answer.ToString() + ",";
                count++;
            }
            BLL.Instance.AddTestHistory(t, st, time_start, time_finish, answer_record);
            Session["ketqua"] = BLL.Instance.TakeTestHistory_ID();
            Session["test"] = null;
            return RedirectToAction("History", "Student");
        }
        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            var old_pw = collection["old_password"];
            var new_pw = collection["new_password"];
            var check_pw = collection["check_newpassword"];
            var name = collection["name_change"];
            var mail = collection["mail_change"];
            var number = collection["number_change"];
            var dob = collection["dob_change"];
            var gender = collection["gender_change"];
            Student st = (Student)Session["user"];
            if(old_pw!=null)
            {
                if (st.Account.Password == old_pw.ToString() && new_pw == check_pw)
                {
                    BLL.Instance.ChangePassword(new_pw, st.Student_ID.ToString());
                    Session["user"] = null;
                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    if (st.Account.Password != old_pw.ToString())
                    {
                        ViewData["thongbao2"] = "Your password field is uncorrect.";
                    }
                    else
                    {
                        ViewData["thongbao2"] = "You re-type new password uncorrectly.";
                    }
                }
            }
            if (name!=null)
            {
                ViewData["thongbao2"] = BLL.Instance.Check_Update_detailstudent(st.Student_ID.ToString(),name.ToString(),mail.ToString(),number.ToString(),Convert.ToDateTime(dob),gender.ToString());
            }
            
            return View();
        }
    }
}