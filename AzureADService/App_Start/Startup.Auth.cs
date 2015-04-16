using System.Configuration;
using Microsoft.Owin.Security.ActiveDirectory;
using Owin;

namespace AzureAD
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            var options = new WindowsAzureActiveDirectoryBearerAuthenticationOptions
                          {
                              Audience = ConfigurationManager.AppSettings["Audience"],
                              Tenant = ConfigurationManager.AppSettings["Tenant"],
                              TokenValidationParameters = new System.IdentityModel.Tokens.TokenValidationParameters() { ValidateIssuer = false }
                          };
            app.UseWindowsAzureActiveDirectoryBearerAuthentication(
                options);
        }
    }
}
