using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineTesting.Models
{
    [Table("Question_In_Test_History")]
    public class Question_In_Test_History
    {
        /*
         * VI DU 1 QUESTION IN TEST HISTORY:
         *      Question_In_Test_History_ID : Qith1
         *      Test_H_ID: TeH1  //Tim cac cau hoi trong Test history thong qua Test_H_ID
         *      Question_In_Test_H_Description: "abcdef ?"
         */
        [Key]
        [Required]
        public string Question_In_Test_History_ID { get; set; }
        public string Test_H_ID { get; set; }
        public string Question_In_Test_H_Description { get; set; }

    }
}