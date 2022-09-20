using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurRetur_KørselsLogbog
{
   public class Bruger
    {
        public int  MedarbejderID { get; set; }
        public string Fornavn { get; set; }
        public string Efternavn { get; set; }
        public string NrPlade { get; set; }
        public string Email { get; set; }

        private string myVar;

        public string AlInfo
        {
            get 
            {           // sends back "M-id: A234, John Larsen. Nr-p: AK47567 (John@gmailcom)" 
                return $"M-id: { MedarbejderID }, { Fornavn } { Efternavn }. Nr-p: { NrPlade } ({ Email }) "; 
            }
        }

    }
}
