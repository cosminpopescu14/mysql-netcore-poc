using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PocWeb
{   
    public class DBConn : IDisposable
    {
        public readonly MySqlConnection connection;
        private static string CONNECTION_STRING = "host=127.0.0.1;port=3306;user id=root;password=root;database=sakila;";

        public DBConn()
        {
            this.connection = new MySqlConnection(CONNECTION_STRING);
        }

        public void Dispose() => connection.Dispose();
    }
}
