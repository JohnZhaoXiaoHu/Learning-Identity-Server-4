using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using AuthServer.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace AuthServer
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddIdentityServer()
                .AddDeveloperSigningCredential()
                //.AddSigningCredential(new X509Certificate2(@"D:\Projects\test\socialnetwork.pfx", "Bx@steel"))
                .AddInMemoryIdentityResources(InMemoryConfiguration.IdentityResources())
                .AddTestUsers(InMemoryConfiguration.Users().ToList())
                .AddInMemoryClients(InMemoryConfiguration.Clients())
                .AddInMemoryApiResources(InMemoryConfiguration.ApiResources());

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseIdentityServer();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
        }
    }
}
