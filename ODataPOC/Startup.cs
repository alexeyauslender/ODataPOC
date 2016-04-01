using System;
using EmbeddedAuthorizationServer.Provider;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using ODataPOC;
using Owin;

[assembly: OwinStartup(typeof (Startup))]

namespace ODataPOC
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //app.UseCookieAuthentication(new CookieAuthenticationOptions
            //{
            //    AuthenticationType = "AppCookies",
            //    LoginPath = new PathString("/users/login"),
            //});

            app.UseOAuthAuthorizationServer(new OAuthAuthorizationServerOptions
            {
                // for demo purposes
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromHours(8),
                Provider = new SimpleAuthorizationServerProvider()
            });

            // token consumption
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
}