using MapDomain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MapWeb.Models
{
    public class SkillRessourceViewModel
    {
        [Key]
        public int id { get; set; }

        
        public int IdRessource { get; set; }
       
        public Ressource Ressource { get; set; }
        public float SkillRate { get; set; }
        public int IdSkill { get; set; }
        
        public Skills Skill { get; set; }
        public string nomressource { get; set; }
        public string nomskill { get; set; }

    }
}