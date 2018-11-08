using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapDomain.Entities
{
    public class Skills
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SkillId { get; set; }
        public string SkillName { get; set; }
        [DataType(DataType.MultilineText)]
        public string SkillDescription { get; set; }
        [Required]
        public float SkillRate { get; set; }
        public virtual ICollection<Ressource> Ressources { get; set; }

    }
}
