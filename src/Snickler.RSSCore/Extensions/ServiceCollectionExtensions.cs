using Microsoft.Extensions.DependencyInjection;
using Snickler.RSSCore.Providers;

namespace Snickler.RSSCore.Extensions
{
   public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRSSFeed<TRSSProvider>(this IServiceCollection services) where TRSSProvider : class, IRSSProvider
        {
           return services.AddScoped<IRSSProvider,TRSSProvider>()
                          .AddScoped<RSSService>();
        }
    }
}
