using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;
using Snickler.RSSCore.Models;

namespace Snickler.RSSCore
{
   public class RSSMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly RSSFeedOptions _rssOptions;
        private readonly string _urlPath;
        public RSSMiddleware(RequestDelegate next, string urlPath, RSSFeedOptions rssOptions)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
            _urlPath = urlPath ?? throw new ArgumentNullException(nameof(urlPath));
            _rssOptions = rssOptions;
        }

        public async Task Invoke(HttpContext context, RSSService rssService)
        {
            if(context.Request.Path.Equals(_urlPath))
            {
                context.Response.ContentType = "application/rss+xml";
                var rssFeed = await rssService.BuildRSSFeed(_rssOptions).ConfigureAwait(false);
                if(!string.IsNullOrEmpty(rssFeed))
                {
                    await context.Response.WriteAsync(rssFeed).ConfigureAwait(false);
                }
            }
            await _next(context);
        }
    }
}
