using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.Extensions.PlatformAbstractions;
using System.IO;
using System.Xml.XPath;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace aspnetcore.swagger
{
    public class Startup
    {

        //宿主变量
        private readonly IHostingEnvironment _hostingEnv;


        public IConfigurationRoot Configuration { get; }

        public Startup(IHostingEnvironment env)
        {
            _hostingEnv = env;

            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            // Register the Swagger generator, defining one or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });

                // Set the comments path for the Swagger JSON and UI.
                //var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                //var xmlPath = Path.Combine(basePath, "aspnetcore.swagger.xml");
                //c.IncludeXmlComments(xmlPath);
                var comments = new XPathDocument($"{AppContext.BaseDirectory}{Path.DirectorySeparatorChar}{_hostingEnv.ApplicationName}.xml");
                c.OperationFilter<XmlCommentsOperationFilter>(comments);

                //c.AddSecurityDefinition("Bearer", new ApiKeyScheme() { In = "header", Description = "Please insert JWT with Bearer into field", Name = "Authorization", Type = "apiKey" });
                // Define the OAuth2.0 scheme that's in use (i.e. Implicit Flow)
                c.AddSecurityDefinition("oauth2", new OAuth2Scheme
                {
                    Type = "oauth2",
                    Flow = "passwrod",
                    AuthorizationUrl = "http://zapdev.highzap.com/api/oauth2/token",
                    Scopes = new Dictionary<string, string>
                    {
                        { "读权限", "Access read operations" },
                        { "写权限", "Access write operations" }
                    },
                    TokenUrl= "http://zapdev.highzap.com/api/oauth2/token",
                    Description="oauth2授权 密码模式"
                });
                // Assign scope requirements to operations based on AuthorizeAttribute
                // 指定范围的要求，基于AuthorizeAttribute业务
                c.OperationFilter<SecurityRequirementsOperationFilter>();

            });
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                // Provide client ID, client secret, realm and application name
                //提供客户端ID、客户端机密、域和应用程序名
                c.ConfigureOAuth2("12", "client_secret", "zapdev.highzap.com", "sale.webapp");
            });
            app.UseMvc();
        }
    }
}
