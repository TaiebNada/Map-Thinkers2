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

        [Required(ErrorMessage = "Ce champ est obligatoire")]
        public String JobOfferDesrip { get; set; }

        [Required(ErrorMessage = "Ce champ est obligatoire")]
        public String Required_Profile { get; set; }
        [Required(ErrorMessage = "Ce champ est obligatoire")]
        [DataType(DataType.Date)]
        public DateTime DateDeb { get; set; }
        [Required(ErrorMessage = "Ce champ est obligatoire")]
        [DataType(DataType.Date)]
        public DateTime DateFin { get; set; }
        [Required(ErrorMessage = "Ce champ est obligatoire")]
        public String Experience { get; set; }

        [Required(ErrorMessage = "Ce champ est obligatoire")]
        public String Function { get; set; }
        [Range(1, 100)]
        
        [Required(ErrorMessage = "Ce champ est obligatoire")]
        public int Poste_numb { get; set; }


    }

}