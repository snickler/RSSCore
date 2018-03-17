using Microsoft.AspNetCore.Builder;
using Snickler.RSSCore.Models;

namespace Snickler.RSSCore.Extensions
{
   public static class AppBuilderExtensions
    {
        public static IApplicationBuilder UseRssFeed(this IApplicationBuilder builder, string path, RSSFeedOptions options)
        {
            return builder.UseMiddleware<RSSMiddleware>(path, options);
        }
    }
}
