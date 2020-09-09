using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MakaPrueba.Data;
using MakaPrueba.Datos.IServices;
using MakaPrueba.Datos.Services;
using MakaPrueba.Negoci.IServices;
using MakaPrueba.Negoci.Services;
using MakaPrueba.Datos.Context;
using Microsoft.EntityFrameworkCore;

namespace MakaPrueba
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();

            var sqlConnectionString = Configuration.GetConnectionString("DataAccessSQLServerProvider");
            services.AddDbContext<MakaContext>(options => options.UseSqlServer(sqlConnectionString,
                                                                                                        option =>
                                                                                                        {
                                                                                                            option.MigrationsAssembly("MakaPrueba.Datos");
                                                                                                        }
                                                                                    ));

            /*Services Business*/
            services.AddTransient<IBusinessServicePerson, BusinessServicePerson>();
            services.AddTransient<IBusinessServicePersonType, BusinessServicesPersonType>();
            /*Services Data*/
            services.AddTransient<IDataServicesPerson, DataServicesPerson>();
            services.AddTransient<IDataServicesPersonType, DataServicesPersonType>();


            //services.AddTransient<IDataServicesPerson, DataServicesPerson>();
            //services./*AddSingleton*/<IDataServicesPerson, DataServicesPerson>();
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
