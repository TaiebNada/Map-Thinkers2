using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapDomain.Entities
{
    public class Message
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MessageId { get; set; }
        public string MessageType { get; set; }
        [Required]
        public string MessageObject { get; set; }
        [DataType(DataType.MultilineText)]
        public string MessageContent { get; set; }
        public int UserId { get; set; }
        public Ressource Ressource { get; set; }
        public Client Client { get; set; }
    }
}
