using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapDomain.Entities
{
   public class SkillRessource
    {
        [Key]
        public int id { get; set; }
       
        public float SkillRate { get; set; }
       
        public int IdRessource { get; set; }
        [ForeignKey("IdRessource")]
        public Ressource Ressource { get; set; }
        public int IdSkill { get; set; }
        [ForeignKey("IdSkill")]
        public Skills Skill { get; set; }
       
    }
}
