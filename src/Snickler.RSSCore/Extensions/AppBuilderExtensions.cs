using Microsoft.AspNetCore.Builder;
using Snickler.RSSCore.Models;

namespace Snickler.RSSCore.Extensions
{
    public static class AppBuilderExtensions
    {
        public static IApplicationBuilder UseRSSFeed(this IApplicationBuilder builder, string path, RSSFeedOptions options)
        {
            return builder.UseWhen(context => context.Request.Path.Value.ToLower() == path, config =>
              {
                  config.UseMiddleware<RSSMiddleware>(path, options);
              });

        }
    }
}
