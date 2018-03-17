using System;
using System.Xml;
using Snickler.RSSCore.Models;
using Microsoft.SyndicationFeed;
using Microsoft.SyndicationFeed.Rss;
using System.Globalization;
using System.IO;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Snickler.RSSCore.Providers;
using Snickler.RSSCore.Extensions;
namespace Snickler.RSSCore
{
    public class RSSService
    {
        private readonly IRSSProvider _rssProvider;
        public RSSService(IRSSProvider rssProvider)
        {
            _rssProvider = rssProvider;
        }

        public async Task<string> BuildRSSFeed(RSSFeedOptions rssOptions)
        {

            if (rssOptions == null)
            {
                throw new ArgumentNullException(nameof(rssOptions));
            }

            if (string.IsNullOrEmpty(rssOptions.Title))
            {
                throw new ArgumentNullException(nameof(rssOptions.Title));
            }

            var sb = new StringBuilder();
            using (var _ = new StringWriter(sb))
            using (XmlWriter xmlWriter = XmlWriter.Create(_, new XmlWriterSettings { Async = true, Indent = true }))
            {
                //Since the XmlWriter doesn't care about actually setting UTF-8, let's just do it manually
                await xmlWriter.WriteProcessingInstructionAsync("xml", @"version=""1.0"" encoding=""UTF-8""");

                var syndicationFeedWriter = new RssFeedWriter(xmlWriter);
                await syndicationFeedWriter.WriteTitle(rssOptions.Title).ConfigureAwait(false);

                if (!string.IsNullOrEmpty(rssOptions.Description))
                {
                    await syndicationFeedWriter.WriteDescription(rssOptions.Description).ConfigureAwait(false);
                }
                if (rssOptions.Url != null)
                {
                    await syndicationFeedWriter.Write(new SyndicationLink(rssOptions.Url)).ConfigureAwait(false);
                    if (rssOptions.ImageUrl != null)
                    {
                        await syndicationFeedWriter.Write(new SyndicationImage(rssOptions.ImageUrl)
                        {
                            Title = rssOptions.Title,
                            Link = new SyndicationLink(rssOptions.Url)
                        }).ConfigureAwait(false);
                    }
                }

                //Choose the current culture if no language has been chosen
                await syndicationFeedWriter.WriteLanguage(rssOptions.Language ?? CultureInfo.CurrentCulture).ConfigureAwait(false);

                if (!string.IsNullOrEmpty(rssOptions.ManagingEditor))
                {
                    await syndicationFeedWriter.Write(new SyndicationPerson(null, rssOptions.ManagingEditor, RssContributorTypes.ManagingEditor)).ConfigureAwait(false);
                }
                //Do we even still care about Webmaster? 
                if (!string.IsNullOrEmpty(rssOptions.Webmaster))
                {
                    await syndicationFeedWriter.WriteValue("webMaster", rssOptions.Webmaster).ConfigureAwait(false);
                }

                if (!string.IsNullOrEmpty(rssOptions.Copyright))
                {
                    await syndicationFeedWriter.WriteCopyright(rssOptions.Copyright).ConfigureAwait(false);
                }

                var syndicationItems = await _rssProvider.RetrieveSyndicationItems().ConfigureAwait(false);

                //Use the latest LastUpdated item in the list to determine the last build date. 
                await syndicationFeedWriter.WriteLastBuildDate(syndicationItems.Max(x => x.LastUpdated)).ConfigureAwait(false);
                foreach (var __ in syndicationItems)
                {
                    await syndicationFeedWriter.Write(__.ToSyndicationItem()).ConfigureAwait(false);
                }
                await xmlWriter.FlushAsync().ConfigureAwait(false);
            }
            return sb.ToString();
        }
    }
}