using System;
using System.Collections.Generic;
namespace Snickler.RSSCore.Models
{
    public class RSSItem
    {
        public string Title { get;set; }
        public string Content { get; set;}
        public Uri FeaturedImage { get;set; }
        public List<string> Categories { get; } = new List<string>();
        public List<string> Authors { get; } = new List<string>();
        public Uri LinkUri { get;set; }
        public Uri PermaLink { get;set; }
        public Uri CommentsUri { get;set; }
        public DateTime LastUpdated{ get;set; }
        public DateTime PublishDate { get;set; }
    }
}