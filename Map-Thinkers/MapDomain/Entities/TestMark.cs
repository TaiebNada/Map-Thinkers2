using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapDomain.Entities
{
  public class TestMark
    {
        [Key, Column(Order = 0)]
        public int TestId { get; set; }
        [Key, Column(Order = 1)]
        public int? UserId { get; set; }
       
        public virtual Test t { get; set; }
        public virtual Candidate c { get; set; }
        public int mark { get; set; }


    }
}
