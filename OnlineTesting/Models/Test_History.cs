using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineTesting.Models
{
    [Table("Test_History")]
    /*
     * VI DU 1 TEST HISTORY:
     *      ID : Teh1
     *      Question_In_Test_H_ID: Qsit1,Qsit2  //dung de biet duoc so cau hoi co trong de
     *      Class_H_Name: 10A1
     *      Subject_H_Name: Toan
     *      Teacher_H_Name: Hoai Phuong
     *      Test_H_Description: Test 01
     *      Time_H_timeStart: 1/1/2022 7:00:00 AM
     *      Time_H_timeEnd: 6/19/2022 12:00:00 PM
     *      Test_H_Duration: 45
     *      Student_ID: St1
     */
    public class Test_History
    {
        [Key]
        [Required]
        public string Test_History_ID { get; set; }
        public string Question_In_Test_H_ID { get; set; }
        public string Class_H_Name { get; set; }
        public string Subject_H_Name { get; set; }
        public string Student_ID { get; set; }
        public string Teacher_H_Name { get; set; }
        public string Test_H_Description { get; set; }
        public int Test_H_Duration { get; set; }
        public string Test_H_timeStart { get; set; }
        public string Test_H_timeFinish { get; set; }
    }
}