using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliverySystem.Models
{
    internal class Admin
    {
        public int Id { get; set; }
        public string Nickname { get; set; }
        public string HashPassword { get; set; }
    }
}
