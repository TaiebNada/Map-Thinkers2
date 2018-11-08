using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapDomain.Entities
{
    public enum StateType { Refused, Accepted, OnHold }
    public class JobRequest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int JobRequestId { get; set; }
        public DateTime RequestDate { get; set; }
        public string Speciality { get; set; }
        public StateType JobRequestState { get; set; }
    }
}
