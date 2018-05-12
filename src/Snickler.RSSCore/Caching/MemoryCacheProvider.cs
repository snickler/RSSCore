using Snickler.RSSCore.Providers;
using System;

namespace Snickler.RSSCore.Caching
{
    public class MemoryCacheProvider : IRSSCacheProvider
    {
        public TimeSpan CacheDuration { get; set; }
        public string Key { get; set; }
    }
}
