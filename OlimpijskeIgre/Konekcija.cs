using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
namespace OlimpijskeIgre
{
    internal class Konekcija
    {
        static public SqlConnection Connect()
        {
            string cs = ConfigurationManager.ConnectionStrings["Olimpijada"].ConnectionString;
            SqlConnection veza = new SqlConnection(cs);
            return veza;
        }
    }
}