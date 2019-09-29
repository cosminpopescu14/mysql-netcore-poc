using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PocWeb
{
    public class CacheKeys
    {
        private CacheKeys() { }

        public static string Films { get { return nameof(Films); } }

    }
}
