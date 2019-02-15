using BaseProj.Api.Treatments.Enums;
using BaseProj.Company;
using BaseProj.Core;
using BaseProj.Entry;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

using SecurityKeyFromCore = BaseProj.Core.Provider.SecurityKey;

namespace BaseProj.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(
                options => options.AddPolicy(
                    "AllowAll", p =>
                    {
                        p.AllowAnyOrigin();
                        p.AllowAnyMethod();
                        p.AllowAnyHeader();
                    }
                )
            );

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(option =>
                {
                    option.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,

                        ValidIssuer = "security.baseproj.com.br",
                        ValidAudience = "security.baseproj.com.br",
                        IssuerSigningKey = SecurityKeyFromCore.Create("lllc.baseproj.dotnetcore")
                    };

                    option.Events = new JwtBearerEvents
                    {
                        OnAuthenticationFailed = context =>
                        {
                            Debug.WriteLine($"OnAuthenticationFailed: {context.Exception.Message}");

                            return Task.CompletedTask;
                        },
                        OnTokenValidated = context =>
                        {
                            Debug.WriteLine($"OnTokenValidated {context.SecurityToken}");

                            if (context.IsPublicMethod(Configuration))
                                context.Success();
                            else context.Fail(Err.UserDoesNotHavePermission.ToDescription());

                            return Task.CompletedTask;
                        }
                    };
                });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("UserAccess",
                    policy =>
                    {
                        policy.RequireClaim("UserId");
                    });
            });

            services.AddMvc();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new Info
                    {
                        Title = "BaseProj API",
                        Version = "1.0.0.0",
                        Description = "Serviço de sistema BaseProj em formato API REST ASP.NET Core.",
                        Contact = new Contact
                        {
                            Name = "Luiz de Queiroz",
                            Email = "oluizdequeiroz@gmail.com"
                        }
                    }
                );

                string applicationPath = PlatformServices.Default.Application.ApplicationBasePath;
                string applicationName = PlatformServices.Default.Application.ApplicationName;
                string xmlApplicationDocPath = Path.Combine(applicationPath, $"{applicationName}.xml");

                c.IncludeXmlComments(xmlApplicationDocPath);
            });
            
            //services.ConfigureConnection(Configuration.GetConnectionString("development"));
            services.ConfigureConnection(Configuration.GetConnectionString("production"));

            services.Inject<IEntryModule, EntryModule>()
                    .Inject<ICompanyModule, CompanyModule>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("AllowAll");

            app.UseAuthentication();
            app.UseStaticFiles();

            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("v1/swagger.json", "BaseProj API");
            });
        }
    }
}
