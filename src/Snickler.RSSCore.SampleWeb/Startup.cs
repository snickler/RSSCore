using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Snickler.RSSCore.Extensions;
namespace Snickler.RSSCore.SampleWeb
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRSSFeed<SampleRSSProvider>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRSSFeed("/feed", new Models.RSSFeedOptions
            {
                Title = "Sample RSS Feed",
                Copyright = "2017",
                Description = "Some Sample RSS Feed You'll Like",
                ManagingEditor = "managingeditor@someaddress.com",
                Webmaster = "webmaster@someaddress.com",
                Url = new Uri("http://someaddress.com")
            });
            app.UseMvc();
        }
    }
}
