using CottageTemperature.Libraries.Configuration;
using CottageTemperature.Libraries.Core.Services;
using CottageTemperature.Libraries.IO;
using CottageTemperature.Libraries.MediatR.Commands;
using CottageTemperature.Libraries.MediatR.Handlers;
using CottageTemperature.Libraries.Telegram;
using CottageTemperature.Web.Extensions;
using CottageTemperature.Web.MapperProfiles;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CottageTemperature.Web
{
    /// <summary>
    ///     Startup class.
    /// </summary>
    public class Startup
    {
        /// <summary>
        ///     Configuration of web application.
        /// </summary>
        private IConfiguration Configuration { get; }

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="configuration"> IConfiguration instance. </param>
        public Startup(IConfiguration configuration) => Configuration = configuration;
        
        /// <summary>
        ///     Method for configure web app services.
        /// </summary>
        /// <param name="services"> Service collection. </param>
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddMediatR(typeof(BaseCommand))
                .AddAutoMapper(config => config.AddProfile<TelegramMapperProfile>())
                .AddConfigurationParser(Configuration)
                .AddTransient<IBotService, BotService>()
                .AddTransient<ISerialPortService, SerialPortService>()
                .AddScoped<IRequestHandler<InfoCommand, Unit>, InfoCommandHandler>()
                .AddControllers()
                .AddNewtonsoftJson();
        }

        /// <summary>
        ///     This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"> IApplication Builder object. </param>
        /// <param name="env"> IWwbHostEnvironment object. </param>
        public static void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseRouting();

            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}