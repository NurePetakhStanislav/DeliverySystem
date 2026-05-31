using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliverySystem.Models
{
    public class Courier
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Status { get; set; }
        public int StreetId { get; set; }
    }
}
