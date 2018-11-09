using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapDomain.Entities
{
   public class JobOffer
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int JobOfferId { get; set; }
        public String JobOfferDesrip { get; set; }
        public String Required_Profile { get; set; }
        public DateTime DateDeb { get; set; }
        public DateTime DateFin { get; set; }

        public String Experience { get; set; }
        public String Function { get; set; }

        public int Poste_numb { get; set; }



    }
}
