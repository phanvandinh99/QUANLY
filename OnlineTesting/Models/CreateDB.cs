using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OnlineTesting.Models
{
    public class CreateDB :
        //CreateDatabaseIfNotExists<Model_OT>
        //DropCreateDatabaseIfModelChanges<Model_OT>
        DropCreateDatabaseAlways<Model_OT>
    {
        protected override void Seed(Model_OT context)
        {
            context.Classrooms.AddRange(new Classroom[]
            {
                new Classroom {Classroom_ID = "C100000", Classroom_Name = "10A1", Classroom_Grade = "10"},
                new Classroom {Classroom_ID = "C100001", Classroom_Name = "10A2", Classroom_Grade = "10"},
                new Classroom {Classroom_ID = "C100002", Classroom_Name = "11A1", Classroom_Grade = "11"},
                new Classroom {Classroom_ID = "C100003", Classroom_Name = "11A2", Classroom_Grade = "11"},
                new Classroom {Classroom_ID = "C100004", Classroom_Name = "12A1", Classroom_Grade = "12"},
                new Classroom {Classroom_ID = "C100005", Classroom_Name = "12A2", Classroom_Grade = "12"}
            });
            context.Subjects.AddRange(new Subject[]
            {
                new Subject {Subject_ID = "S100000", Subject_Name = "Toan"},
                new Subject {Subject_ID = "S100001", Subject_Name = "Ly"},
                new Subject {Subject_ID = "S100002", Subject_Name = "Hoa"}
            });
            context.Accounts.AddRange(new Account[]
            {
                new Account {ID = "St100000", Password = "123", IsLock = 0, Name = "Tuan Hung", DoB = Convert.ToDateTime("02-12-2002"), IsMale = 1, ContactNumber = "0999888777", MailAddress = "st1@gmail.com" },
                new Account {ID = "St100001", Password = "123", IsLock = 0, Name = "Tien Hoang", DoB = Convert.ToDateTime("03-11-2002"), IsMale = 0, ContactNumber = "0987556444", MailAddress = "st2@gmail.com" },
                new Account {ID = "Tc100000", Password = "123", IsLock = 0, Name = "Hoai Phuong", DoB = Convert.ToDateTime("11-10-2002"), IsMale = 0, ContactNumber = "0464576668", MailAddress = "Tc100000@gmail.com" },
                new Account {ID = "Tc100001", Password = "123", IsLock = 0, Name = "Van Ha", DoB = Convert.ToDateTime("07-09-2002"), IsMale = 0, ContactNumber = "0876678556", MailAddress = "Tc100001@gmail.com" },
                new Account {ID = "Ad100000", Password = "123", IsLock = 0, Name = "Admin", DoB = Convert.ToDateTime("12-09-2002"), IsMale = 0, ContactNumber = "0678675566", MailAddress = "ad@gmail.com" }
            });
            context.Students.AddRange(new Student[]
            {
                new Student {Student_ID = "St100000", Classroom_ID = "C100000"},
                new Student {Student_ID = "St100001", Classroom_ID = "C100001"}
            });
            context.Teachers.AddRange(new Teacher[]
            {
                new Teacher {Teacher_ID = "Tc100000", Subject_ID = "S100000"},
                new Teacher {Teacher_ID = "Tc100001", Subject_ID = "S100001"}
            });
            context.Questions.AddRange(new Question[]
            {
                new Question {Question_ID = "Qs100000", Question_Grade = "10", Teacher_ID = "Tc100000", Subject_ID = "S100000", Question_Description = "Phương trình đường thẳng denta đi qua A(1;-2) và song song với đường thẳng (d) : 2x-3y+2=0", Question_isLock = false },
                new Question {Question_ID = "Qs100001", Question_Grade = "10", Teacher_ID = "Tc100000", Subject_ID = "S100000", Question_Description = "Cho tam giác ABC với AB=c, BC=a, AC=b và bán kính đường tròn ngoại tiếp bằng R, trong các mệnh đề sau, mệnh đề sai là:", Question_isLock = false },
                new Question {Question_ID = "Qs100002", Question_Grade = "10", Teacher_ID = "Tc100000", Subject_ID = "S100000", Question_Description = "Miền nghiệm của bất phương trình -x+2+2(y-2)<2(1-x) không chứa điểm:", Question_isLock = false },
                new Question {Question_ID = "Qs100003", Question_Grade = "10", Teacher_ID = "Tc100000", Subject_ID = "S100000", Question_Description = "Cho bất phương trình sau: 2x+3y-6 <= 0. Chọn khẳng định đúng:", Question_isLock = false },
                
                new Question {Question_ID = "Qs100004", Question_Grade = "10", Teacher_ID = "Tc100000", Subject_ID = "S100000", Question_Description = "Cho phương trình 3x - 2y = 5. Tập nghiệm của phương trình là: ", Question_isLock = false },
                new Question {Question_ID = "Qs100005", Question_Grade = "10", Teacher_ID = "Tc100000", Subject_ID = "S100000", Question_Description = "Hệ phương trình: mx+y=m+1 và x-my=2017 có nghiệm khi:", Question_isLock = false },
                new Question {Question_ID = "Qs100006", Question_Grade = "10", Teacher_ID = "Tc100000", Subject_ID = "S100000", Question_Description = "Cặp số (1;-1) là nghiệm của bất phương trình nào sau đây?", Question_isLock = false },
                new Question {Question_ID = "Qs100007", Question_Grade = "10", Teacher_ID = "Tc100000", Subject_ID = "S100000", Question_Description = "Cặp số nào sau đây là nghiệm của bất phương trình -2(x - y) + y > 3 ?", Question_isLock = false },
                
                new Question {Question_ID = "Qs100008", Question_Grade = "10", Teacher_ID = "Tc100000", Subject_ID = "S100000", Question_Description = "Tìm a biết sin(a)=1 ?", Question_isLock = false },
                new Question {Question_ID = "Qs100009", Question_Grade = "10", Teacher_ID = "Tc100000", Subject_ID = "S100000", Question_Description = "Cho tam giác ABC vuông cân tại A và AB = 2. M là trung điểm AB. Khi đó tan góc (MCB) bằng :", Question_isLock = false },
                new Question {Question_ID = "Qs100010", Question_Grade = "10", Teacher_ID = "Tc100000", Subject_ID = "S100000", Question_Description = "Tam giác ABC có a=10cm, b=8cm, c=6cm. Góc B bằng: ", Question_isLock = false },
                new Question {Question_ID = "Qs100011", Question_Grade = "10", Teacher_ID = "Tc100000", Subject_ID = "S100000", Question_Description = "Khoảng cách từ điểm M(-2;2) đến đường thẳng p : 5x-12y+8=0 bằng: ", Question_isLock = false },
            });
            context.Answers.AddRange(new Answer[]
            {
                new Answer {Answer_ID = "As100000", Question_ID = "Qs100000", Answer_Description = "2x-3y-8=0", Answer_isTrue = true, Answer_Explaination = ""},
                new Answer {Answer_ID = "As100001", Question_ID = "Qs100000", Answer_Description = "2x-3y+8=0", Answer_isTrue = false, Answer_Explaination = ""},
                new Answer {Answer_ID = "As100002", Question_ID = "Qs100000", Answer_Description = "2x-3y-6=0", Answer_isTrue = false, Answer_Explaination = ""},
                new Answer {Answer_ID = "As100003", Question_ID = "Qs100000", Answer_Description = "2x-3y+6=0", Answer_isTrue = false, Answer_Explaination = ""},

                new Answer {Answer_ID = "As100004", Question_ID = "Qs100001", Answer_Description = "b = 2Rsin(A)", Answer_isTrue = true, Answer_Explaination = ""},
                new Answer {Answer_ID = "As100005", Question_ID = "Qs100001", Answer_Description = "b = [asin(B)]/[sin(A)]", Answer_isTrue = false, Answer_Explaination = ""},
                new Answer {Answer_ID = "As100006", Question_ID = "Qs100001", Answer_Description = "c = 2Rsin(C)", Answer_isTrue = false, Answer_Explaination = ""},
                new Answer {Answer_ID = "As100007", Question_ID = "Qs100001", Answer_Description = "a/sin(A) = 2R", Answer_isTrue = false, Answer_Explaination = ""},

                new Answer {Answer_ID = "As100008", Question_ID = "Qs100002", Answer_Description = "(1;-1)", Answer_isTrue = false, Answer_Explaination = "aaa"},
                new Answer {Answer_ID = "As100009", Question_ID = "Qs100002", Answer_Description = "(4;2)", Answer_isTrue = true, Answer_Explaination = ""},
                new Answer {Answer_ID = "As100010", Question_ID = "Qs100002", Answer_Description = "(-4;2)", Answer_isTrue = false, Answer_Explaination = ""},
                new Answer {Answer_ID = "As100011", Question_ID = "Qs100002", Answer_Description = "(3;4)", Answer_isTrue = false, Answer_Explaination = ""},

                new Answer {Answer_ID = "As100012", Question_ID = "Qs100003", Answer_Description = "BPT có 1 nghiệm duy nhất", Answer_isTrue = false, Answer_Explaination = ""},
                new Answer {Answer_ID = "As100013", Question_ID = "Qs100003", Answer_Description = "BPT vô nghiệm", Answer_isTrue = false, Answer_Explaination = ""},
                new Answer {Answer_ID = "As100014", Question_ID = "Qs100003", Answer_Description = "BPT luôn có vô số nghiệm", Answer_isTrue = true, Answer_Explaination = ""},
                new Answer {Answer_ID = "As100015", Question_ID = "Qs100003", Answer_Description = "BPT có tập nghiệm là R", Answer_isTrue = false, Answer_Explaination = ""},

                new Answer {Answer_ID = "As100016", Question_ID = "Qs100008", Answer_Description = "k2π", Answer_isTrue = false, Answer_Explaination = ""},
                new Answer {Answer_ID = "As100017", Question_ID = "Qs100008", Answer_Description = "kπ", Answer_isTrue = false, Answer_Explaination = ""},
                new Answer {Answer_ID = "As100018", Question_ID = "Qs100008", Answer_Description = "π/2 + kπ", Answer_isTrue = false, Answer_Explaination = ""},
                new Answer {Answer_ID = "As100019", Question_ID = "Qs100008", Answer_Description = "π/2 + k2π", Answer_isTrue = true, Answer_Explaination = ""},

                new Answer {Answer_ID = "As100020", Question_ID = "Qs100009", Answer_Description = "1/2", Answer_isTrue = false, Answer_Explaination = ""},
                new Answer {Answer_ID = "As100021", Question_ID = "Qs100009", Answer_Description = "1/5", Answer_isTrue = false, Answer_Explaination = ""},
                new Answer {Answer_ID = "As100022", Question_ID = "Qs100009", Answer_Description = "1/3", Answer_isTrue = true, Answer_Explaination = ""},
                new Answer {Answer_ID = "As100023", Question_ID = "Qs100009", Answer_Description = "1/6", Answer_isTrue = false, Answer_Explaination = ""},

                new Answer {Answer_ID = "As100024", Question_ID = "Qs100010", Answer_Description = "52°8'", Answer_isTrue = false, Answer_Explaination = ""},
                new Answer {Answer_ID = "As100025", Question_ID = "Qs100010", Answer_Description = "53°8'", Answer_isTrue = true, Answer_Explaination = ""},
                new Answer {Answer_ID = "As100026", Question_ID = "Qs100010", Answer_Description = "54°8'", Answer_isTrue = false, Answer_Explaination = ""},
                new Answer {Answer_ID = "As100027", Question_ID = "Qs100010", Answer_Description = "55°8'", Answer_isTrue = false, Answer_Explaination = ""},

                new Answer {Answer_ID = "As100028", Question_ID = "Qs100011", Answer_Description = "2", Answer_isTrue = true, Answer_Explaination = ""},
                new Answer {Answer_ID = "As100029", Question_ID = "Qs100011", Answer_Description = "13", Answer_isTrue = false, Answer_Explaination = ""},
                new Answer {Answer_ID = "As100030", Question_ID = "Qs100011", Answer_Description = "2/13", Answer_isTrue = false, Answer_Explaination = ""},
                new Answer {Answer_ID = "As100031", Question_ID = "Qs100011", Answer_Description = "-2", Answer_isTrue = false, Answer_Explaination = ""},

                new Answer {Answer_ID = "As100032", Question_ID = "Qs100004", Answer_Description = "{(x;3/2(x)-5/2),x∈R}", Answer_isTrue = true, Answer_Explaination = ""},
                new Answer {Answer_ID = "As100033", Question_ID = "Qs100004", Answer_Description = "{(x;3/2(x)-4/2),x∈R}", Answer_isTrue = false, Answer_Explaination = ""},
                new Answer {Answer_ID = "As100034", Question_ID = "Qs100004", Answer_Description = "{(x;5/2(x)-5/2),x∈R}", Answer_isTrue = false, Answer_Explaination = ""},
                new Answer {Answer_ID = "As100035", Question_ID = "Qs100004", Answer_Description = "{(x;2/3(x)-5/2),x∈R}", Answer_isTrue = false, Answer_Explaination = ""},

                new Answer {Answer_ID = "As100036", Question_ID = "Qs100005", Answer_Description = "m≠1", Answer_isTrue = false, Answer_Explaination = ""},
                new Answer {Answer_ID = "As100037", Question_ID = "Qs100005", Answer_Description = "m≠-1", Answer_isTrue = false, Answer_Explaination = ""},
                new Answer {Answer_ID = "As100038", Question_ID = "Qs100005", Answer_Description = "m≠+1", Answer_isTrue = false, Answer_Explaination = ""},
                new Answer {Answer_ID = "As100039", Question_ID = "Qs100005", Answer_Description = "Mọi giá trị m", Answer_isTrue = true, Answer_Explaination = ""},

                new Answer {Answer_ID = "As100040", Question_ID = "Qs100006", Answer_Description = "x + 3y + 1 < 0", Answer_isTrue = true, Answer_Explaination = ""},
                new Answer {Answer_ID = "As100041", Question_ID = "Qs100006", Answer_Description = "-x - 3y - 1 < 0", Answer_isTrue = false, Answer_Explaination = ""},
                new Answer {Answer_ID = "As100042", Question_ID = "Qs100006", Answer_Description = "x - 3y + 1 < 0", Answer_isTrue = false, Answer_Explaination = ""},
                new Answer {Answer_ID = "As100043", Question_ID = "Qs100006", Answer_Description = "x - 3y - 1 < 0", Answer_isTrue = false, Answer_Explaination = ""},

                new Answer {Answer_ID = "As100044", Question_ID = "Qs100007", Answer_Description = "(-3;4)", Answer_isTrue = false, Answer_Explaination = ""},
                new Answer {Answer_ID = "As100045", Question_ID = "Qs100007", Answer_Description = "(-4;4)", Answer_isTrue = false, Answer_Explaination = ""},
                new Answer {Answer_ID = "As100046", Question_ID = "Qs100007", Answer_Description = "(4;-4)", Answer_isTrue = false, Answer_Explaination = ""},
                new Answer {Answer_ID = "As100047", Question_ID = "Qs100007", Answer_Description = "(4;4)", Answer_isTrue = true, Answer_Explaination = ""},
            });
            //duration
            context.Tests.AddRange(new Test[]
            {
                new Test {Test_ID = "Te100000", Question_In_Test_ID = "Qs100000,Qs100001,Qs100008", Class_ID = "C100000", Subject_ID = "S100000", Teacher_ID = "Tc100000"
                , Test_Description = "Test 01", Test_isLock = false, Test_timeStart = Convert.ToDateTime("01-01-2022 7:00:00 AM")
                , Test_timeEnd = Convert.ToDateTime("06-28-2022 12:00:00"), Test_Duration=9},
            });
            
            context.Question_In_Tests.AddRange(new Question_In_Test[]
            {
                new Question_In_Test {Question_In_Test_ID = "Qsit100000", Test_ID = "Te100000", Question_ID = "Qs100000" , Question_In_Test_Description = "Phương trình đường thẳng denta đi qua A(1;-2) và song song với đường thẳng (d) : 2x-3y+2=0"},
                new Question_In_Test {Question_In_Test_ID = "Qsit100001", Test_ID = "Te100000", Question_ID = "Qs100001" , Question_In_Test_Description = "Cho tam giác ABC với AB=c, BC=a, AC=b và bán kính đường tròn ngoại tiếp bằng R, trong các mệnh đề sau, mệnh đề sai là:"},
                new Question_In_Test {Question_In_Test_ID = "Qsit100002", Test_ID = "Te100000", Question_ID = "Qs100008" , Question_In_Test_Description = "Tìm a biết sin(a)=1 ?"},
            });
            
            context.Answer_In_Tests.AddRange(new Answer_In_Test[]
            {

                new Answer_In_Test {Answer_In_Test_ID = "Asit100000", Question_In_Test_ID = "Qsit100000", Answer_ID = "As100000", Answer_In_Test_isTrue = true, Answer_In_Test_Description = "2x-3y-8=0", Answer_In_Test_Explaination = "" },
                new Answer_In_Test {Answer_In_Test_ID = "Asit100001", Question_In_Test_ID = "Qsit100000", Answer_ID = "As100001", Answer_In_Test_isTrue = false, Answer_In_Test_Description = "2x-3y+8=0", Answer_In_Test_Explaination = "" },
                new Answer_In_Test {Answer_In_Test_ID = "Asit100002", Question_In_Test_ID = "Qsit100000", Answer_ID = "As100002", Answer_In_Test_isTrue = false, Answer_In_Test_Description = "2x-3y-6=0", Answer_In_Test_Explaination = "" },
                new Answer_In_Test {Answer_In_Test_ID = "Asit100003", Question_In_Test_ID = "Qsit100000", Answer_ID = "As100003", Answer_In_Test_isTrue = false, Answer_In_Test_Description = "2x-3y+6=0", Answer_In_Test_Explaination = "" },
                
                new Answer_In_Test {Answer_In_Test_ID = "Asit100004", Question_In_Test_ID = "Qsit100001", Answer_ID = "As100004", Answer_In_Test_isTrue = true, Answer_In_Test_Description = "b = 2Rsin(A)", Answer_In_Test_Explaination = "" },
                new Answer_In_Test {Answer_In_Test_ID = "Asit100005", Question_In_Test_ID = "Qsit100001", Answer_ID = "As100005", Answer_In_Test_isTrue = false, Answer_In_Test_Description = "b = [asin(B)]/[sin(A)]", Answer_In_Test_Explaination = "" },
                new Answer_In_Test {Answer_In_Test_ID = "Asit100006", Question_In_Test_ID = "Qsit100001", Answer_ID = "As100006", Answer_In_Test_isTrue = false, Answer_In_Test_Description = "c = 2Rsin(C)", Answer_In_Test_Explaination = "" },
                new Answer_In_Test {Answer_In_Test_ID = "Asit100007", Question_In_Test_ID = "Qsit100001", Answer_ID = "As100007", Answer_In_Test_isTrue = false, Answer_In_Test_Description = "a/sin(A) = 2R", Answer_In_Test_Explaination = "" },
                
                new Answer_In_Test {Answer_In_Test_ID = "Asit100008", Question_In_Test_ID = "Qsit100002", Answer_ID = "As100016", Answer_In_Test_isTrue = false, Answer_In_Test_Description = "k2π", Answer_In_Test_Explaination = "" },
                new Answer_In_Test {Answer_In_Test_ID = "Asit100009", Question_In_Test_ID = "Qsit100002", Answer_ID = "As100017", Answer_In_Test_isTrue = false, Answer_In_Test_Description = "kπ", Answer_In_Test_Explaination = "" },
                new Answer_In_Test {Answer_In_Test_ID = "Asit100010", Question_In_Test_ID = "Qsit100002", Answer_ID = "As100018", Answer_In_Test_isTrue = false, Answer_In_Test_Description = "π/2 + kπ", Answer_In_Test_Explaination = "" },
                new Answer_In_Test {Answer_In_Test_ID = "Asit100011", Question_In_Test_ID = "Qsit100002", Answer_ID = "As100019", Answer_In_Test_isTrue = true, Answer_In_Test_Description = "π/2 + k2π", Answer_In_Test_Explaination = "" }
            });
        }
    }
}