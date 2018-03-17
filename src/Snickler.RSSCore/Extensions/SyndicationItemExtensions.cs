using System;
using System.Linq;
using Microsoft.SyndicationFeed;
using Microsoft.SyndicationFeed.Rss;
using Snickler.RSSCore.Models;

namespace Snickler.RSSCore.Extensions
{
    public static class SyndicationItemExtensions
    {
        public static ISyndicationItem ToSyndicationItem(this RSSItem rssItem)
        {
            if(rssItem == null)
            {
                throw new ArgumentException(nameof(rssItem));
            }

            //Should probably have an item title
            if(string.IsNullOrEmpty(rssItem.Title))
            {
                throw new ArgumentNullException(nameof(rssItem.Title));
            }

            //And some content
            if(string.IsNullOrEmpty(rssItem.Content))
            {
                throw new ArgumentNullException(nameof(rssItem.Content));
            }

            var syndicationItem = new SyndicationItem
            {
                Title = rssItem.Title,
                Description = rssItem.Content
            };

            if (rssItem.PermaLink != null)
            {
                syndicationItem.AddLink(new SyndicationLink(rssItem.PermaLink, RssLinkTypes.Guid));
            }
            if(rssItem.LinkUri != null)
            {
                syndicationItem.AddLink(new SyndicationLink(rssItem.LinkUri));
            }
            if(rssItem.CommentsUri != null)
            {
                syndicationItem.AddLink(new SyndicationLink(rssItem.CommentsUri, RssLinkTypes.Comments));
            }
        
            rssItem.Authors.ForEach(author=> syndicationItem.AddContributor(new SyndicationPerson(null, author)));
            rssItem.Categories.ForEach(category=> syndicationItem.AddCategory(new SyndicationCategory(category)));
            
            syndicationItem.Published = rssItem.PublishDate;

            return syndicationItem;
        }
    }
}