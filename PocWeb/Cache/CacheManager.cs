using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.Extensions.Caching.Memory;

namespace PocWeb.Cache
{
    public class CacheManager
    {
        public MemoryCache memoryCache { get; set; }

        public CacheManager()
        {
            memoryCache = new MemoryCache(new MemoryCacheOptions
            {
                SizeLimit = 2048 // no unit like bytes
            });
        }
    }
}
