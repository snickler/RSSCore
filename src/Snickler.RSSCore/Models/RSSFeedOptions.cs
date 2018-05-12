using Snickler.RSSCore.Providers;
using System;
using System.Globalization;

namespace Snickler.RSSCore.Models
{
   public class RSSFeedOptions
    {
        public string Title {get;set;}
        public string Description {get;set;}
        public string ManagingEditor {get;set;}
        public string Webmaster {get;set;}
        public string Copyright {get;set;}
        public Uri Url {get;set;}
        public Uri ImageUrl {get;set;}
        public CultureInfo Language {get;set;}
        public IRSSCacheProvider Caching { get; set; }
    }
}
