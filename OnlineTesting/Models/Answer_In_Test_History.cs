using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineTesting.Models
{
    [Table("Answer_In_Test_History")]
    public class Answer_In_Test_History
    {
        /*
         * VI DU 1 ANSWER IN TEST HISTORY:
         *      Answer_In_Test_History_ID : Aith1
         *      Question_In_Test_H_ID: Qith1  //Tim cac cau tra loi cua 1 lich su cau hoi thong qua Question_In_Test_H_ID
         *      Answer_In_Test_H_isTrue: false //cau tra loi co gia tri false
         *      Answer_In_Test_H_Description: "1/3"
         *      Answer_In_Test_H_Explaination: "sai vi abcdefgh."
         */
        [Key]
        [Required]
        public string Answer_In_Test_History_ID { get; set; }
        public string Question_In_Test_H_ID { get; set; }
        public bool Answer_In_Test_H_isTrue { get; set; }
        public string Answer_In_Test_H_Description { get; set; }
        public string Answer_In_Test_H_Explaination { get; set; }
        public bool Answer_In_Test_H_isChoosen { get; set; }
    }
}