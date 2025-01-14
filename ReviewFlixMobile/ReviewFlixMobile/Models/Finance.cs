using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewFlixMobile.Models
{
    public class Finance
    {
        public int Id { get; set; }
        public int FilmId { get; set; }
        public decimal Budget { get; set; }
        public decimal Revenue { get; set; }
    }
}
