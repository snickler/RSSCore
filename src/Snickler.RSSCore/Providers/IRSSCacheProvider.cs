using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snickler.RSSCore.Providers
{
   public interface IRSSCacheProvider
    {
        TimeSpan CacheDuration { get; set; }
        string Key { get; set; }
      
    }
}
