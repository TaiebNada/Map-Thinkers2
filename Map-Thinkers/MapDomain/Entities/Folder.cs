using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapDomain.Entities
{
    public enum StateLetter{  signed, notSigned   }
    public enum StateFolder { notComplited, complited }
    public enum StateMinister {notAccepted, Accepted, inPregress, notSend }
    public class Folder
    {
       

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FolderId { get; set; }
        public String LettreDefault { get; set; }
        public String LettreSigned { get; set; }
        public StateLetter Condition { get; set; }
        public StateFolder FolderState { get; set; }
        public StateMinister MinisterState  { get; set; }

        [ForeignKey("JobRequest")]
        public int JobRequestId { get; set; }
        public JobRequest JobRequest { get; set; }
       


    }
}
