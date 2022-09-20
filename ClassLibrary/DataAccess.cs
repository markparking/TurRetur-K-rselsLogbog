using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MySql.Data.MySqlClient;

namespace TurRetur_KørselsLogbog
{
    public class DataAccess
    {
        public List<Bruger> GetBrugere()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("KørselLogDB")))
            {
                return connection.Query<Bruger>($"SELECT * FROM Brugere").ToList();
            }
        }
    }
}
