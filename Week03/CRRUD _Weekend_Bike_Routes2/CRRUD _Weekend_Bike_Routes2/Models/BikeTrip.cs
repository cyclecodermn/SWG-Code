using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRRUD__Weekend_Bike_Routes2.Models
{
    public class BikeTrip
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CloseCity { get; set; }
        public string CampName { get; set; }
        public int NightlyCost { get; set; }
        public int Distance { get; set; }
        public string Difficulty { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
