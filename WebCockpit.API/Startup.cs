using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Diagnostics;
using WebCockpit.Application.Interfaces;
using WebCockpit.Application.Services;
using WebCockpit.Infrastructure;
using WebCockpit.Infrastructure.Filters;

namespace WebCockpit.API
{
    public class Startup
    {
        private IntPtr _hwnd;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            _hwnd = Process.GetCurrentProcess().Handle;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(options =>
            {
                options.Filters.Add<ExceptionFilter>();
            });

            services.AddSingleton<ISimConnectContext>(new SimConnectContext(_hwnd));
            services.AddTransient<IWriteService, WriteService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
