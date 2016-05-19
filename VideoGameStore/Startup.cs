using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VideoGameStore.Startup))]
namespace VideoGameStore
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
          ConfigureAuth(app);
        }
    }
}
