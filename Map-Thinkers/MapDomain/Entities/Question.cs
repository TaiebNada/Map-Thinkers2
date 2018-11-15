using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapDomain.Entities
{
  public class Question
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int QuestionId { get; set; }
        public String subject { get; set; }
        public String choice1 { get; set; }
        public String choice2 { get; set; }
        public String choice3 { get; set; }
        public String validchoice { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
    }
}
