using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliverySystem.Models
{
    internal class Road
    {
        public int FromStreetId { get; set; }
        public int ToStreetId { get; set; }
        public int Distance { get; set; }
        public List<string> DeliveryFactors { get; set; } = new();
    }
}
