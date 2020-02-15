using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;
using Microsoft.Owin.Security.OAuth;

[assembly: OwinStartup(typeof(AirPollutionBackend.Startup))]

namespace AirPollutionBackend
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);
            ConfigureAuth(app);
        }
    }
}
