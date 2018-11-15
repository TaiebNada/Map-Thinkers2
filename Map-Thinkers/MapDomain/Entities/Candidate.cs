using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapDomain.Entities
{
 

    public  class Candidate : User
    {

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        public string Picture { get; set; }

        public WorkType WorkType { get; set; }
        public virtual ICollection<JobRequest> JobRequests { get; set; }

        public virtual ICollection<Test> Tests { get; set; }
    }
}
