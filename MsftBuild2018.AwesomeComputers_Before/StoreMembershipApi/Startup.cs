using System.Threading.Tasks;
using Bazinga.AspNetCore.Authentication.Basic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace StoreMembershipApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment env)
		{
			var builder = new ConfigurationBuilder()
				.SetBasePath(env.ContentRootPath)
				.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
				.AddEnvironmentVariables();

			Configuration = builder.Build();
		}

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

			// NOTE: DO NOT USE THIS IN A PRODUCTION APPLICATION
			// THIS IS JUST AN EXAMPLE OF WORKING WITH AN AUTH SCHEME WITHIN YOUR POLICIES
	        var basicAuthUsername = Configuration.GetValue<string>("BasicAuth:Username");
	        var basicAuthPassword = Configuration.GetValue<string>("BasicAuth:Password");
			services.AddAuthentication(BasicAuthenticationDefaults.AuthenticationScheme)
		        .AddBasicAuthentication(credentials =>
			        Task.FromResult(
				        credentials.username == basicAuthUsername
						&& credentials.password == basicAuthPassword));
		}

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

	        app.UseAuthentication();
			app.UseMvc();
        }
    }
}
