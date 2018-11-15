using MapDomain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MapWeb.Models
{
    public class SkillsViewModel
    {
     
        public string SkillName { get; set; }
        [DataType(DataType.MultilineText)]
        public string SkillDescription { get; set; }
        [Required]
        public float SkillRate { get; set; }
        public virtual ICollection<SkillRessource> SkillRessource { get; set; }

    }
}