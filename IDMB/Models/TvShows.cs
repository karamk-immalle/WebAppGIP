using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IDMB.Models
{
    public class TvShows
    {
        public int Id { get; set; }

        [Required]
        public string Naam { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Datum van publicatie")]
        public DateTime DatumVanPublicatie { get; set; }

        [Required]
        public string Genre { get; set; }

        [Required]
        [Display(Name = "Aantal afleveringen")]
        [NotNegative] 
        public int AantalAflevering { get; set; }
    }

    public class NotNegativeAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
           
            int getal;
            if (int.TryParse(value.ToString(), out getal))
            {

                if (getal >= 0)
                    return true;
            }
            return false;
        }
    }
}
