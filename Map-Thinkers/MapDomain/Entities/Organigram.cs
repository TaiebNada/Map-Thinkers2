using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapDomain.Entities
{
    public class Organigram
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrganigramId { get; set; }
        [Required]
        public string DirectionLevel { get; set; }
        [Required]
        public string ProjectName { get; set; }
        [Required]
        public string ProgramName { get; set; }
        [Required]
        public string CustomerName { get; set; }
        public int NbrResourcesOn { get; set; }
        public virtual ICollection<Ressource> Resssources { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
    }
}
