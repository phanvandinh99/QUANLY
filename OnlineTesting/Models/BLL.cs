using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineTesting.Models
{
    public class BLL
    {
        Model_OT db = new Model_OT();
        private static BLL _Instance;
        public static BLL Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new BLL();
                return _Instance;
            }
            private set { }
        }
        public Student TakeStudentfromLogin(string id, string pw)
        {
            Student st = new Student();
            st = db.Students.Find(id);
            if (st!=null && st.Account.Password == pw)
                return st;
            else
                return null;
        }
        public bool IsNumber(string pValue)
        {
            foreach (Char c in pValue)
            {
                if (!Char.IsDigit(c))
                    return false;
            }
            return true;
        }
        public bool IsName(string pValue)
        {
            foreach (Char c in pValue)
            {
                if (Char.IsDigit(c))
                    return false;
                if ((int)c < 65 && (int)c!=32)
                    return false;
                if ((int)c > 122 && (int)c != 32)
                    return false;
                if ((int)c > 90 && (int)c < 97 && (int)c != 32)
                    return false;
            }
            return true;
        }
        public bool IsEmail(string pValue)
        {
            foreach (Char c in pValue)
            {
                if (c=='@')
                    return true;
            }
            return false;
        }
        public void ChangePassword(string pw, string id)
        {
            var s = db.Students.Find(id);
            s.Account.Password = pw;
            db.SaveChanges();
        }
        public string Check_Update_detailstudent(string id,string name, string mail, string number, DateTime dob, string gender)
        {
            if (!IsNumber(number)) return "Number is not available [0..9].";
            if (!IsName(name)) return "Name is not available. [it contains special characters or numbers]";
            if (!IsEmail(mail)) return "Mail is not available. [it should have '@']";
            var s = db.Students.Find(id);
            s.Account.IsMale = gender == "male" ? 1 : 0;
            s.Account.Name = name;
            s.Account.ContactNumber = number;
            s.Account.DoB = Convert.ToDateTime(dob.ToShortDateString());
            s.Account.MailAddress = mail;
            db.SaveChanges();
            return "Change Successful";
        }
        public List<Test> TakeAllTestByClassID(string id)
        {
            List<Test> lst = new List<Test>();
            var l = db.Tests.Where(p => p.Class_ID == id).Select(p => p);
            lst = l.ToList();
            return lst;
        }
        public Test TakeTestByTestID(string id)
        {
            Test t = new Test();
            if (id!=null) t = db.Tests.Find(id);
            return t;
        }
        public bool CheckTestAvailable(Test t)
        {
            if (DateTime.Compare(DateTime.Now,Convert.ToDateTime(t.Test_timeEnd))<0 &&t.Test_isLock==false) return true;
            else return false;
        }
        public bool CheckEndTimeinTest(Test t)
        {
            if (DateTime.Compare(DateTime.Now, Convert.ToDateTime(t.Test_timeEnd)) < 0) return true;
            else return false;
        }
        public List<Question_In_Test> TakeQuestionInTest(string q_in_test_id)
        {
            List<Question_In_Test> l = new List<Question_In_Test>();
            List<Question_In_Test> list = new List<Question_In_Test>();
            Question_In_Test question = new Question_In_Test();
            string s = q_in_test_id;
            foreach(string qst in s.Split(','))
            {
                l = db.Question_In_Tests.Where(p=>p.Question_ID==qst).Select(p=>p).ToList();
                question = l[0];
                list.Add(question);
            }
            return list;
        }
        public List<Answer_In_Test> TakeAnswerInTest(string question_in_test_id)
        {
            List<Answer_In_Test> lst = new List<Answer_In_Test>();
            var l = db.Answer_In_Tests.Where(p => p.Question_In_Test_ID == question_in_test_id).Select(p => p);
            lst = l.ToList();
            return lst;
        }
        public int TakeNumberOfQuestionInTest(string testid)
        {
            Test t = db.Tests.Find(testid);
            int count = 0;
            foreach (string qst in t.Question_In_Test_ID.Split(','))
            {
                count++;
            }
            return count;
        }
        public int CountTimesDoingTest(string q_i_t_h_id)
        {
            int count = 0;
            var l = db.Test_Histories.Where(p => p.Question_In_Test_H_ID == q_i_t_h_id).Select(p => p);
            count = l.Count();
            return count;
        }
        public int TakeNumberOfQuestionInTestHistory(string tehid)
        {
            Test_History t = db.Test_Histories.Find(tehid);
            int count = 0;
            foreach (string qst in t.Question_In_Test_H_ID.Split(','))
            {
                count++;
            }
            return count;
        }
        public string TakeAnswerInTestHistory_ID()
        {
            string s = "";
            var l = db.Answer_In_Test_Histories.Select(p => p);
            string index = "";
            int num = 0;
            List<Answer_In_Test_History> lst = new List<Answer_In_Test_History>();
            if (l.ToList().Count() == 0)
                return "Aith100000";
            else
            {
                lst = l.ToList();
                s = lst[lst.Count - 1].Answer_In_Test_History_ID.ToString();
                for (int i = 4; i < s.Length; i++)
                {
                    index = index + s[i];
                }
                num = Convert.ToInt32(index);
                num++;
                s = "Aith" + num.ToString();
                index = "";
                return s;
            }
        }
        public void AddAnswerInTestHistory(Question_In_Test q, string qith_id, string answer_choosen)
        {
            List <Answer_In_Test> l_ans = TakeAnswerInTest(q.Question_In_Test_ID);
            foreach(Answer_In_Test a in l_ans)
            {
                Answer_In_Test_History aith = new Answer_In_Test_History();
                aith.Answer_In_Test_History_ID = TakeAnswerInTestHistory_ID();
                aith.Question_In_Test_H_ID = qith_id;
                aith.Answer_In_Test_H_isTrue = a.Answer_In_Test_isTrue;
                aith.Answer_In_Test_H_Description = a.Answer_In_Test_Description;
                aith.Answer_In_Test_H_Explaination = a.Answer_In_Test_Explaination;
                aith.Answer_In_Test_H_isChoosen = (answer_choosen==a.Answer_In_Test_Description)?true:false;
                db.Answer_In_Test_Histories.Add(aith);
                db.SaveChanges();
            }
        }
        public string TakeQuestionInTestHistory_ID()
        {
            string s = "";
            var l = db.Question_In_Test_Histories.Select(p => p);
            string index = "";
            int num = 0;
            List<Question_In_Test_History> lst = new List<Question_In_Test_History>();
            if (l.ToList().Count() == 0)
                return "Qith100000";
            else
            {
                lst = l.ToList();
                s = lst[lst.Count - 1].Question_In_Test_History_ID.ToString();
                for (int i = 4; i < s.Length; i++)
                {
                    index = index + s[i];
                }
                num = Convert.ToInt32(index);
                num++;
                s = "Qith" + num.ToString();
            }
            return s;
        }
        public void AddQuestionInTestHistory(Test t, string test_history_id, string answer_record)
        {
            List<string> l_ans_record = answer_record.Split(',').ToList();
            int count = 0;
            foreach (Question_In_Test i in TakeQuestionInTest(t.Question_In_Test_ID))
            {
                Question_In_Test_History qith = new Question_In_Test_History();
                qith.Question_In_Test_History_ID = TakeQuestionInTestHistory_ID();
                qith.Question_In_Test_H_Description = i.Question_In_Test_Description;
                qith.Test_H_ID = test_history_id;
                db.Question_In_Test_Histories.Add(qith);
                db.SaveChanges();
                //them answer in test history by question
                AddAnswerInTestHistory(i, qith.Question_In_Test_History_ID, l_ans_record[count]);
                count++;
            }
        }
        public string TakeTestHistory_ID()
        {
            string s = "";
            var l = db.Test_Histories.Select(p => p);
            string index = "";
            int num = 0;
            List<Test_History> lst = new List<Test_History>();
            if (l.ToList().Count()==0)
                return "Teh100000";
            else
            {
                lst = l.ToList();
                s = lst[lst.Count-1].Test_History_ID.ToString();
                for(int i=3;i<s.Length; i++)
                {
                    index = index + s[i];
                }
                num = Convert.ToInt32(index);
                num++;
                s = "Teh" + num.ToString();
            }
            return s;
        }
        public void AddTestHistory(Test t,Student st,string time_start, string time_finish,string answer_record)
        {
            Test_History th = new Test_History();
            th.Test_History_ID = TakeTestHistory_ID();
            th.Question_In_Test_H_ID = t.Question_In_Test_ID;
            th.Test_H_timeStart = time_start;
            th.Test_H_timeFinish = time_finish;
            th.Test_H_Duration = t.Test_Duration;
            th.Class_H_Name = st.Classroom.Classroom_Name;
            th.Teacher_H_Name = t.Teacher.Account.Name;
            th.Subject_H_Name = t.Subject.Subject_Name;
            th.Student_ID = st.Student_ID;
            th.Test_H_Description = t.Test_Description;
            //them qith
            AddQuestionInTestHistory(t, th.Test_History_ID,answer_record);
            db.Test_Histories.Add(th);
            db.SaveChanges();
        }
        public List<Test_History> TakeTestHistoryByStudentID(string id)
        {
            List<Test_History> lst = new List<Test_History>();
            lst = db.Test_Histories.Where(p=>p.Student_ID==id).Select(p => p).ToList();
            return lst;
        }
        public Test_History TakeTestHistoryByID(string id)
        {
            Test_History th = db.Test_Histories.Find(id);
            return th;
        }
        public List<Question_In_Test_History> TakeQITHByTH_ID(string th_id)
        {
            List<Question_In_Test_History> l = new List<Question_In_Test_History>();
            l = db.Question_In_Test_Histories.Where(p => p.Test_H_ID == th_id).Select(p => p).ToList();
            return l;
        }
        public List<Answer_In_Test_History> TakeAITHByQITH_ID(string qith_id)
        {
            List<Answer_In_Test_History> l = new List<Answer_In_Test_History>();
            l = db.Answer_In_Test_Histories.Where(p=>p.Question_In_Test_H_ID==qith_id).Select(p => p).ToList();
            return l;
        }
        public int GetScoreFromTestHistory_ID(string th_id)
        {
            int point = 0;
            List<Question_In_Test_History> l = new List<Question_In_Test_History>();
            l = db.Question_In_Test_Histories.Where(p => p.Test_H_ID == th_id).Select(p => p).ToList();
            foreach(Question_In_Test_History qith in l)
            {
                foreach(Answer_In_Test_History aith in TakeAITHByQITH_ID(qith.Question_In_Test_History_ID))
                {
                    if (aith.Answer_In_Test_H_isTrue == true & aith.Answer_In_Test_H_isChoosen == true)
                        point++;
                }
            }
            return point;
        }
    }
}