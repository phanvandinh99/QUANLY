using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineTesting.Models
{
    [Table("Answer_In_Test")]
    public class Answer_In_Test
    {
        [Key]
        public string Answer_In_Test_ID { get; set; }
        public string Question_In_Test_ID { get; set; }
        public string Answer_ID { get; set; }
        [ForeignKey("Answer_ID"), Column(Order = 0)]
        public virtual Answer Answer { get; set; }
        public bool Answer_In_Test_isTrue { get; set; }
        public string Answer_In_Test_Description { get; set; }
        public string Answer_In_Test_Explaination { get; set; }
        //public virtual Answer_In_Test_History Answer_In_Test_History { get; set; }
    }
}