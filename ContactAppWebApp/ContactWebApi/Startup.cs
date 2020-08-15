using AutoMapper;
using ContactWebApi.Extensions;
using Entity.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository;
using Services;
using System;
using System.IO;
using System.Reflection;

namespace ContactWebApi
{
    /// <summary>
    /// Application Startup class
    /// </summary>
    public class Startup
    {
        #region Property and Variable

        /// <summary>
        /// Application Configuration
        /// </summary>
        public IConfiguration Configuration { get; }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        #endregion

        #region Methods

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            RegisterRepository(services);
            RegisterServices(services);

            services.AddCors(options =>
            {
                options.AddPolicy("EVOLCore",
                                  builder =>
                                  {
                                      builder.AllowAnyHeader().AllowAnyMethod().AllowCredentials().SetIsOriginAllowed((host) => true);
                                  });
            });
            ConfigureSwagger(services);
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddControllers().AddNewtonsoftJson();

        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.EnvironmentName == "Dev")
            {
                app.UseDeveloperExceptionPage();
            }
            app.ConfigureCustomExceptionMiddleware(); // Reg Custom middleware here
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProConfigApp V1");
            });
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseCors("EVOLCore");
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
        /// <summary>
        /// Regsiter application services
        /// </summary>
        /// <param name="services"></param>
        public void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IContactService, ContactService>();
        }

        /// <summary>
        /// Register Application Repository
        /// </summary>
        /// <param name="services"></param>
        private static void RegisterRepository(IServiceCollection services)
        {
            services.AddScoped<IRepository<Contact>, Repository<Contact>>();
        }

        /// <summary>
        /// Configure Swagger for your API 
        /// </summary>
        /// <param name="services"></param>
        private static void ConfigureSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo() { Title = "Contact Application", Version = "V1", Description = "Development Only" });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }
        #endregion
    }
}
