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
            var synd1 = new RSSItem("Sample Title 1", "Sample Content 1")
            {
                PermaLink = new Uri("http://www.sampleaddress.com/sample-content-1"),
                LinkUri = new Uri("http://www.sampleaddress.com/sample-content-1"),
                LastUpdated = DateTime.Now,
                PublishDate = DateTime.Now,
                Categories = new List<string> { ".NET" },
                Authors = new List<string> { "someuser@sampleaddress.com" }
            };

            var synd2 = new RSSItem(null, "Sample Content 2")
            {
                PermaLink = new Uri("http://www.sampleaddress.com/sample-content-2"),
                LinkUri = new Uri("http://www.sampleaddress.com/sample-content-2"),
                LastUpdated = DateTime.Now,
                PublishDate = DateTime.Now,
                Categories = new List<string> { ".NET" }
            };

            var synd3 = new RSSItem("Sample Title 3", null)
            {
                PermaLink = new Uri("http://www.sampleaddress.com/sample-content-3"),
                LinkUri = new Uri("http://www.sampleaddress.com/sample-content-3"),
                LastUpdated = DateTime.Now,
                PublishDate = DateTime.Now,
                Authors = new List<string> { "someotheruser@sampleaddress.com" }
            };

            var synd4 = new RSSItem("Sample Title 4", null)
            {
                PermaLink = new Uri("http://www.sampleaddress.com/sample-content-4"),
                LinkUri = new Uri("http://www.sampleaddress.com/sample-content-4"),
                LastUpdated = DateTime.Now,
                PublishDate = DateTime.Now
            };

            syndicationList.Add(synd1);
            syndicationList.Add(synd2);
            syndicationList.Add(synd3);
            syndicationList.Add(synd4); 

            return Task.FromResult(syndicationList);
        }
    }
}
