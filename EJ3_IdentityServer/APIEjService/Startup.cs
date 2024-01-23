using APIEjService.Models;
using IdentityServer3.AccessTokenValidation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Jwt;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

[assembly: OwinStartup(typeof(AuthenticatedAPIEjService.Startup))]
namespace AuthenticatedAPIEjService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }

        private void ConfigureAuth(IAppBuilder app)
        {
            // Configuración para consumir el token en la API protegida
            var issuer = "http://localhost:7777/identity";
            var audience = "http://localhost:7777/identity/resources";
            var secretKey = "secret";

            app.UseJwtBearerAuthentication(new JwtBearerAuthenticationOptions
            {
                AuthenticationMode = AuthenticationMode.Active,
                TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = issuer,
                    ValidateAudience = true,
                    ValidAudience = audience,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.Default.GetBytes(secretKey)),
                    ClockSkew = TimeSpan.FromMinutes(5)
                }
            });

            // Configuración de Web API
            HttpConfiguration config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();

            app.UseWebApi(config);

            app.Use(async (context, next) =>
            {
                await next.Invoke();
               // LogToEventViewer("Authentication Type: " + context.Authentication.AuthenticationResponseGrant?.Identity?.AuthenticationType);
            });

            /*
            app.UseIdentityServerBearerTokenAuthentication(new IdentityServerBearerTokenAuthenticationOptions
            {
                Authority = "http://localhost:7777/identity",
                ValidationMode = ValidationMode.ValidationEndpoint,
                RequiredScopes = new[] { "api1" },
                AuthenticationType = "Bearer",
                ClientId = "client1",
                ClientSecret = "secret",
               // IssuerName = "http://localhost:7777/identity",
               SigningCertificate = Cert.Load(),
                TokenProvider = new OAuthBearerAuthenticationProvider
                {
                    OnValidateIdentity = async context =>
                    {
                        LogToEventViewer("Fallo en la autenticación.");
                        if (context.Ticket != null && context.Ticket.Identity != null && context.Ticket.Identity.IsAuthenticated)
                        {
                            // La identidad ha sido validada exitosamente. Puedes escribir un evento de log aquí.
                            LogToEventViewer("Autenticación exitosa para el usuario: " + context.Ticket.Identity.Name);
                        }
                        else
                        {
                            // La identidad no ha sido validada. Puedes escribir un evento de log aquí.
                            LogToEventViewer("Fallo en la autenticación.");
                        }
                    }
                }

            }) ;
            */

        }

        private void LogToEventViewer(string message)
        {
            const string logName = "kkLog"; // Puedes cambiar esto según tus necesidades
            /*
            if (!EventLog.SourceExists(logName))
            {
                EventLog.CreateEventSource(logName, "Application");
            }
            */
            using (EventLog eventLog = new EventLog("Application"))
            {
                eventLog.Source = logName;
                eventLog.WriteEntry(message, EventLogEntryType.Information);
            }
        }
    }
}
