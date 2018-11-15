using MapDomain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MapWeb.Models.RadhouenModels
{
    public class TestModel
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TestId { get; set; }
        public TypeTest Type { get; set; }
        public String Version { get; set; }


        [ForeignKey("Folder")]
        public int FolderId { get; set; }
        public Folder Folder { get; set; }

        public ICollection<Question> Questions { get; set; }
        public ICollection<Folder> Folders { get; set; }
        public int score { get; set; }

    }
}