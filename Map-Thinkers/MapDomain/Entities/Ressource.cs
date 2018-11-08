using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapDomain.Entities
{

    public enum ContractType { Employee, Freelancer }
    public enum WorkType { IT, HR, Finance, Administration }
    public enum AvailibilityType { Available, Unavailable, AvailableSoon }
    public class Ressource : User
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public ContractType ContractType { get; set; }
        public string Seniority { get; set; }
        public string Cv { get; set; }
        public string Picture { get; set; }
        public WorkType WorkType { get; set; }
        public AvailibilityType AvailabilityType { get; set; }
        public string Note { get; set; }
        public float Taux { get; set; } = 1.8f;
        public virtual ICollection<Message> Messages { get; set; }
        public virtual ICollection<Holiday> Holidays { get; set; }
        public virtual ICollection<DayOff> DayOffs { get; set; }
        public virtual ICollection<Organigram> Organigrams { get; set; }

        public virtual ICollection<Project> Projects { get; set; }
        public virtual ICollection<Skills> Skills { get; set; }

    }
}
