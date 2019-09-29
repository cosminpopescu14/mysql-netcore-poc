using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PocWeb.DAL
{
    public interface IRepository
    {
        Task<IEnumerable<Film>> GetFilmsAsync();
    }
}
