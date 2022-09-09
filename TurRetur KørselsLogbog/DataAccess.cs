using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace TurRetur_KørselsLogbog
{
    public class DataAccess
    {
        public List<Bruger> GetBrugere(string Fornavn)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("KørselLogDB"))
            {

            }
        }
    }
}
