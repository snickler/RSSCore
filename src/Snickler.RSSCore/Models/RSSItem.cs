using System;
using System.Collections.Generic;
namespace Snickler.RSSCore.Models
{
    public class RSSItem
    {
        public RSSItem(string title, string content)
        {
            // An RSS item should contain at least either a title or the content. It doesn't have to contain both.  
            // According to the specification here: https://validator.w3.org/feed/docs/rss2.html#hrelementsOfLtitemgt 
            if (string.IsNullOrEmpty(title) && string.IsNullOrEmpty(content))
            {
                throw new ArgumentNullException(nameof(title), $"{nameof(Title)} is required unless {nameof(Content)} is provided.");
            }
            this.Title = title;
            this.Content = content; 
        }

        public string Title { get; }
        public string Content { get; }
        public Uri FeaturedImage { get;set; }
        public List<string> Categories { get; set; }
        public List<string> Authors { get; set; }
        public Uri LinkUri { get;set; }
        public Uri PermaLink { get;set; }
        public Uri CommentsUri { get;set; }
        public DateTime LastUpdated{ get;set; }
        public DateTime PublishDate { get;set; }
    }
}