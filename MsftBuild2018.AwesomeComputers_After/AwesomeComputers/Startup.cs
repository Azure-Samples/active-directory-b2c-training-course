using AwesomeComputers;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Startup))]

namespace AwesomeComputers
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
		{
			ConfigureAuth(app);
		}
    }
}
