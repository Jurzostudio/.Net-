using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CurrencyTrainer.Startup))]
namespace CurrencyTrainer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
