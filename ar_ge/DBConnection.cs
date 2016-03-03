using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace KobiDestek
{

    class DBConnection
    {
        private DBConnection() { }

        public static SqlConnection createConnection()
        {
            return new SqlConnection(connString);
        }

        private static readonly String host = ".\\SQLEXPRESS";
        private static readonly String dbName = "KOSGEB";
        //private static readonly String username = "sa";
        //private static readonly String pass = "Password123";
        private static readonly String connString = String.Format("Data Source={0}; Initial Catalog={1};Integrated Security=true;", host, dbName);
    }
}
