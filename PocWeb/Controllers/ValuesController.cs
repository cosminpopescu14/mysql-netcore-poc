using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using PocWeb.Cache;
using PocWeb.DAL;

namespace PocWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : CacheController
    {
        private readonly IRepository repository;
        public ValuesController(CacheManager cacheManager, IRepository _repository) : base(cacheManager)
        {
            repository = _repository;
        }
        // GET api/values
        [HttpGet]
        public async Task<IEnumerable<Film>> Get()
        {
            var response = await this.GetOrSetFromCacheAsync(
                key: CacheKeys.Films,
                size: 100,
                method: () => repository.GetFilmsAsync()
                );

            return response;
        }
    }
}
