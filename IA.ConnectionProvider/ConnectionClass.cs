using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IA.ConnectionProvider
{
   public class ConnectionClass
    {

        public static SqlConnection GetConnection()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PROConnectionString"].ConnectionString);
            return con;
        }


    }
}
