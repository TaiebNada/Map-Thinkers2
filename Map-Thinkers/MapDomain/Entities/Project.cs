using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapDomain.Entities
{
    public enum ProjectType { newProject, ProjectInProgress, CompletedProject }
    public class Project
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProjectId { get; set; }
        [Required]
        public string ProjectName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int NbrResources { get; set; }
        public int NbrResourcesLevio { get; set; }
        public string ProjectPicture { get; set; }
        public ProjectType State { get; set; }
        public double Profitability { get; set; }

        public int? UserId { get; set; }


        public virtual Client Client { get; set; }
        [ForeignKey("Organigram")]
        public int OrganigramId { get; set; }
        public Organigram Organigram { get; set; }
        public virtual ICollection<Ressource> Ressources { get; set; }
    }
}
