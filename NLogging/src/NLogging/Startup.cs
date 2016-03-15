using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLogging.Models;
using NLogging.Services;
using Microsoft.Extensions.PlatformAbstractions;
using NLog.Config;
using NLog.Targets;
using NLog;
using NLog.Fluent;

namespace NLogging
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            // Set up configuration sources.

            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsDevelopment())
            {
                // For more details on using the user secret store see http://go.microsoft.com/fwlink/?LinkID=532709
                builder.AddUserSecrets();

                // This will push telemetry data through Application Insights pipeline faster, allowing you to view results immediately.
                builder.AddApplicationInsightsSettings(developerMode: true);
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddApplicationInsightsTelemetry(Configuration);

            services.AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(Configuration["Data:DefaultConnection:ConnectionString"]));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

           
            services.AddMvc();

            //var serviceDescriptor = new ServiceDescriptor(typeof(NLog.ILogger), typeof(Microsoft.Extensions.Logging.ILoggerFactory), ServiceLifetime.Transient);
            //services.Add(serviceDescriptor);
            // Add application services.

            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();

          //  services.AddTransient<Microsoft.Extensions.Logging.ILogger, NLog.Logger>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            var loggerConfig = Configuration.Get<NLogConfig>("NLogConfig");

            var applicationEnvironment = app.ApplicationServices.GetService<IApplicationEnvironment>() as IApplicationEnvironment;

            var config = LoadNLogConfig(loggerConfig, applicationEnvironment.ApplicationBasePath);
            loggerFactory.AddNLog(new LogFactory(config));

            app.UseApplicationInsightsRequestTelemetry();

            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");

                // For more details on creating database during deployment see http://go.microsoft.com/fwlink/?LinkID=615859
                try
                {
                    using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>()
                        .CreateScope())
                    {
                        serviceScope.ServiceProvider.GetService<ApplicationDbContext>()
                             .Database.Migrate();
                    }
                }
                catch { }
            }

            app.UseIISPlatformHandler(options => options.AuthenticationDescriptions.Clear());

            app.UseApplicationInsightsExceptionTelemetry();

            app.UseStaticFiles();

            app.UseIdentity();

            // To configure external authentication please see http://go.microsoft.com/fwlink/?LinkID=532715

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        private LoggingConfiguration LoadNLogConfig(NLogConfig logConfig, string filePath)
        {
            var config = new LoggingConfiguration();

            ConfigurationItemFactory.Default.LayoutRenderers.RegisterDefinition("ApplicationName", typeof(ApplicationNameLayoutRenderer));
            ConfigurationItemFactory.Default.LayoutRenderers.RegisterDefinition("HostAddress", typeof(HostAddressLayoutRenderer));
            //  ConfigurationItemFactory.Default.LayoutRenderers.RegisterDefinition("Custom", typeof(LogEventInfo));

            //Logger logHost = LogManager.GetCurrentClassLogger();
            //LogEventInfo theEvent = new LogEventInfo(NLog.LogLevel.Trace, "", "Vignesh");
            //theEvent.Properties["MyValue"] = "Custom";
            //logHost.Log(theEvent);

            //ConfigurationItemFactory.Default.Layouts.RegisterDefinition("MyValue", typeof(LogEventInfo));

            var fileTarget = new FileTarget
            {
                Name = logConfig.Name,
                KeepFileOpen = logConfig.KeepFileOpen,
                ConcurrentWrites = logConfig.ConcurrentWrites,
                CreateDirs = logConfig.CreateDirectory,
                ArchiveOldFileOnStartup = logConfig.ArchiveOldFileOnStartup,
                FileName = filePath + "\\" + logConfig.FileName,
                Layout = logConfig.Layout
            };

            config.AddTarget("file", fileTarget);
            var level = NLog.LogLevel.FromString(logConfig.Level);

            if (level != null)
            {
                config.LoggingRules.Add(new LoggingRule("*", level, fileTarget));
            }
            return config;
        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
