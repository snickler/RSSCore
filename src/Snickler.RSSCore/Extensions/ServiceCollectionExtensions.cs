using Microsoft.Extensions.DependencyInjection;
using Snickler.RSSCore.Models;
using Snickler.RSSCore.Providers;
using System;
using System.Collections.Generic;
using System.Text;

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
