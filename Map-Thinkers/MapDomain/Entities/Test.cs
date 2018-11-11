using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapDomain.Entities
{
    public enum TypeTest { TestFR,TestTech }
    public class Test
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

    }
}
