using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using MySql.Data.MySqlClient;
using Newtonsoft.Json;

namespace PocWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public /*ActionResult<IEnumerable<string>>*/ string Get()
        {
            var films = new List<Film>();
            using (var db = new DBConn())
            {
                db.connection.Open();
                MySqlCommand cmd = db.connection.CreateCommand();
                cmd.CommandText = "select title, description from film";

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    films.Add(new Film { Title = reader.GetString(0), Description = reader.GetString(1) });
                }

                return JsonConvert.SerializeObject(films);
            }
        }

        // GET api/values/5
        /*[HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/
    }
}
