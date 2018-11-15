using MapDomain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MapWeb.Models.RadhouenModels
{
    public class QuestionModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int QuestionId { get; set; }
        public String subject { get; set; }
        public String choice1 { get; set; }
        public String choice2 { get; set; }
        public String choice3 { get; set; }
        public String validchoice { get; set; }

        public virtual ICollection<Test> Tests { get; set; }

    }
}