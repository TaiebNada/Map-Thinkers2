using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapDomain.Entities
{
    public class InterMandate
    {
        [Key, Column(Order = 0)]
        public int InterMandateId { get; set; }

    }
}
