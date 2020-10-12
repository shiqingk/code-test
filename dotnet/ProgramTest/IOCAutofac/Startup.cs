using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using IOCAutofac.IServices;
using IOCAutofac.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace IOCAutofac
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            var containerBuilder = new ContainerBuilder();
            containerBuilder.Populate(services);

            var arr = Assembly.GetEntryAssembly();
            var arrt = arr.GetReferencedAssemblies();
            var artt = arrt.Select(Assembly.Load).ToArray();
            var types = containerBuilder.RegisterAssemblyTypes(artt);
            var tttt = types.Where(t => t.Name.Contains("Services") && !t.IsAbstract);
            var tbtb = tttt.AsImplementedInterfaces();
            tbtb.InstancePerLifetimeScope();

            //containerBuilder.RegisterAssemblyTypes(Assembly.GetEntryAssembly().GetReferencedAssemblies().Select(Assembly.Load).ToArray())
            //    .Where(t => t.Name.EndsWith("Services") && !t.IsAbstract)
            //    .AsImplementedInterfaces()
            //    .InstancePerLifetimeScope();
            containerBuilder.RegisterGeneric(typeof(TestServices)).As(typeof(ITestServices)).AsImplementedInterfaces().InstancePerLifetimeScope();

            containerBuilder.RegisterGeneric(typeof(BaseServices<>)).As(typeof(IBaseServices<>)).AsImplementedInterfaces().InstancePerLifetimeScope();
            var container = containerBuilder.Build();
            return new AutofacServiceProvider(container);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
