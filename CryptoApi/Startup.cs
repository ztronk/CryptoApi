using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CryptoApi.Startup))]
namespace CryptoApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
