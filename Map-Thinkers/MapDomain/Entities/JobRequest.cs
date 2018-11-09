using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapDomain.Entities
{
    public enum State
    {
        notApplay, interview, testTech, interviewTech, testFr, accepted, applicationAccepted, refused

    }
    public class JobRequest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int JobRequestId { get; set; }
        public DateTime RequestDate { get; set; }
        public string Speciality { get; set; }
        public State JobRequestState { get; set; }

        public String JobRequest_Motivation { get; set; }

        public virtual ICollection<Candidate> Candidates { get; set; }
        public virtual ICollection<JobOffer> JobOffers { get; set; }
    }
}
