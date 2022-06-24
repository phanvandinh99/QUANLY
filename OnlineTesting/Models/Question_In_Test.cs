using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineTesting.Models
{
    [Table("Question_In_Test")]
    public class Question_In_Test
    {
        [Key]
        public string Question_In_Test_ID { get; set; }
        public string Test_ID { get; set; }
        public string Question_ID { get; set; }
        [ForeignKey("Question_ID"), Column(Order = 1)]
        public virtual Question Question { get; set; }
        public string Question_In_Test_Description { get; set; }/*
        public virtual ICollection<Answer_In_Test> Answer_In_Tests { get; set; }*/

    }
}