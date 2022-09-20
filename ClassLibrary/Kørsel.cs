using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurRetur_KørselsLogbog
{
   public class Kørsel
    {
        public int kID { get; set; }
        public string mID { get; set; }
        public int Km { get; set; }
        public DateTime Dato { get; set; }
        public string Note { get; set; }
    }
}
