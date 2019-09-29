using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PocWeb.DAL
{
    public class Repository : IRepository
    {
        public async Task<IEnumerable<Film>> GetFilmsAsync()
        {
            var films = new List<Film>();
            using (var db = new DBConn())
            {
                await db.connection.OpenAsync();
                MySqlCommand cmd = db.connection.CreateCommand();
                cmd.CommandText = "select title, description from film limit 200";

                var reader = await cmd.ExecuteReaderAsync();

                while (reader.Read())
                {
                    films.Add(new Film { Title = await reader.GetFieldValueAsync<string>(0), Description = await reader.GetFieldValueAsync<string>(1) });
                }
                return films;
            }
        }
    }
}
