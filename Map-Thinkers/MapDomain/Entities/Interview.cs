using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapDomain.Entities
{
    public enum TypeInterview{ interview, InterviewTech}
    public enum StateInterview { Request, Accepted, notAccepted }
    public class Interview
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InterviewId { get; set; }
        public DateTime InterviewDate { get; set; }

        public TypeInterview InterviewType { get; set; }
        public StateInterview InterviewState { get; set; }

        public virtual ICollection<JobRequest> JobRequests { get; set; }



    }
}
