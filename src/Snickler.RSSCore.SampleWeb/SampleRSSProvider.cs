using Snickler.RSSCore.Providers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Snickler.RSSCore.Models;

namespace Snickler.RSSCore.SampleWeb
{
    public class SampleRSSProvider : IRSSProvider
    {
        public Task<IList<RSSItem>> RetrieveSyndicationItems()
        {
            IList<RSSItem> syndicationList = new List<RSSItem>();
            var synd1 = new RSSItem()
            {
                Content = "Sample Content 1",
                PermaLink = new Uri("http://www.sampleaddress.com/sample-content-1"),
                LinkUri = new Uri("http://www.sampleaddress.com/sample-content-1"),
                LastUpdated = DateTime.Now,
                PublishDate = DateTime.Now,
                Title = "Sample Title 1",
            };

            synd1.Categories.Add(".NET");
            synd1.Authors.Add("someuser@sampleaddress.com");

            var synd2 = new RSSItem()
            {
                Content = "Sample Content 2",
                PermaLink = new Uri("http://www.sampleaddress.com/sample-content-2"),
                LinkUri = new Uri("http://www.sampleaddress.com/sample-content-2"),
                LastUpdated = DateTime.Now,
                PublishDate = DateTime.Now,
                Title = "Sample Title 2",
            };

            synd2.Categories.Add(".NET");
            synd2.Authors.Add("someotheruser@sampleaddress.com");

            syndicationList.Add(synd1);
            syndicationList.Add(synd2);

            return Task.FromResult(syndicationList);
        }
    }
}
