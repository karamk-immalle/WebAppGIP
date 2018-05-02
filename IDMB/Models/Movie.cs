using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IDMB.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        public string Naam { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Datum van publicatie")]
        public DateTime DatumVanPublicatie { get; set; }

        [Required]
        public string Genre { get; set; }
    }
}
