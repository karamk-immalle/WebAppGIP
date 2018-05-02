using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IDMB.Models
{
    public class TopBoxOffice
    {
        public int Id { get; set; }
        public int Rank { get; set; }
        public string Title { get; set; }
        public string Weekend { get; set; }
        public string Gross { get; set; }
        public int Week { get; set; }
    }
}
