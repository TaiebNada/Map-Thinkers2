using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MapWeb.Models.RadhouenModels
{
    public class JobOfferModels
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int JobOfferId { get; set; }
        public String JobOfferDesrip { get; set; }
        public String Required_Profile { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateDeb { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateFin { get; set; }

        public String Experience { get; set; }
        public String Function { get; set; }

        public int Poste_numb { get; set; }


    }

}