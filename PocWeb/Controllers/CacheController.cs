using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using PocWeb.Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PocWeb
{
    public class CacheController : ControllerBase
    {
        protected readonly CacheManager _cacheManager;

        public CacheController(CacheManager cache)
        {
            this._cacheManager = cache;
        }

        /*
         * Method that add or get values form cache
         * TODO Refactor it
         */
        protected async Task<T> GetOrSetFromCacheAsync<T>(string key, long size, Func<Task<T>> method, double expirationSeconds = 60 * 60 * 24)
        {
            if(!_cacheManager.memoryCache.TryGetValue(key, out T result))
            {
                var cachedItem = await method.Invoke();

                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromSeconds(expirationSeconds))
                    .SetSize(size);

                _cacheManager.memoryCache.Set(key, result, cacheEntryOptions);

                return cachedItem;
            }
            return result;
        }
    }
}
