## Snickler.RSSCore: ASPNETCore Middleware for generating RSS Feeds

[![NuGet](https://img.shields.io/nuget/v/Snickler.RSSCore.svg)](https://www.nuget.org/packages/Snickler.RSSCore)

This library was created in order to provide a way to easily generate RSS feeds on the fly via an ASP.NET Core Middleware. 

### Targets

Currently supports:

* ASPNET Core 1.1 (netstandard1.3)
* ASPNET Core 2.x (netstandard2.0)

### Getting Started

Add the NuGet package to your project(s). Utilize the namespaces: `Snickler.RSSCore.Models`, `Snickler.RSSCore.Providers`, and `Snickler.RSSCore.Extensions`.

#### Create an RSS Provider

Create a provider class that implements `IRSSProvider` and returns a list of `RSSItem` objects via the `RetrieveSyndicationItems` method.

```csharp
public class SomeRSSProvider: IRSSProvider
{
    public Task<IList<RSSItem>> RetrieveSyndicationItems()
        {
            IList<RSSItem> syndicationList = new List<RSSItem>();
            var rssItem1 = new RSSItem()
            {
                Content = "Sample Content 1",
                PermaLink = new Uri("http://www.sampleaddress.com/sample-1"),
                LinkUri = new Uri("http://www.sampleaddress.com/Item.aspx?Id=423"),
                LastUpdated = DateTime.Now,
                PublishDate = DateTime.Now,
                Title = "Sample Title 1",
            };

            rssItem1.Categories.Add(".NET");
            rssItem1.Authors.Add("someuser@sampleaddress.com");

            syndicationList.Add(synd1);

            return Task.FromResult(syndicationList);
        }
}
```

#### RSS Feed Configuration

Add your provider to the service registration in `ConfigureServices` with the `AddRSSFeed` extension

```csharp
       public void ConfigureServices(IServiceCollection services)
        {
            services.AddRSSFeed<SomeRSSProvider>();
            services.AddMvc();
        }
```

Set the options for your RSS Feed in `Configure` with `UseRSSFeed`

```csharp

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseRssFeed("/feed", new RSSFeedOptions
            {
                Title = "Snickler's Super Awesome RSS Feed",
                Copyright = "2018",
                Description = "The Best and Most Awesome RSS Feed Content",
                ManagingEditor = "managingeditor@someaddress.com",
                Webmaster = "webmaster@someaddress.com",
                Url = new Uri("http://someaddress.com")
            });
        }

```

### Optional RSS Caching Configuration

By default, MemoryCache is used to cache the feed for 1 day. To be able to update the cache duration or cache key, add a new instance of the `MemoryCacheProvider` to the `Caching` property within the `RSSFeedOptions` class. 

```csharp

            app.UseRssFeed("/feed", new RSSFeedOptions
            {
                Title = "Snickler's Super Awesome RSS Feed",
                Copyright = "2018",
                Description = "The Best and Most Awesome RSS Feed Content",
                ManagingEditor = "managingeditor@someaddress.com",
                Webmaster = "webmaster@someaddress.com",
                Url = new Uri("http://someaddress.com"),
                Caching = new MemoryCacheProvider 
                {
                    CacheDuration = TimeSpan.FromDays(5),
                    CacheKey = "SomeSuperAwesomeCacheKey"
                }
            });

```


With this example setup, you'll be able to access the feed at http://whateverurl.com/feed

### Example Project

An example project is located within the .sln file in the source. 
