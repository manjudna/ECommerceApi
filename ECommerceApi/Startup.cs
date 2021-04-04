using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceApi.Data;
using ECommerceApi.Mapper;
using ECommerceApi.Models;
using System.Text.Json.Serialization;
using ECommerceApi.Interfaces;
using ECommerceApi.Services;
using AutoMapper;
using ECommerceApi.Repository;

namespace ECommerceApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSwaggerGen();

            services.AddDbContext<ECommerceApiContext>(opt=>opt.UseInMemoryDatabase(databaseName: "InMemoryDb"));

            services.AddScoped<ILaptopService, LaptopService>();
            services.AddScoped<IConfigurationService, ConfigurationService>();
            services.AddScoped<IShoppingCartService, ShoppingCartService>();
            services.AddScoped<ILaptopRepository, LaptopRepository>();
            services.AddScoped<IConfigurationRepository, ConfigurationRepository>();
            services.AddScoped<IShoppingCartRepository, ShoppingCartRepository>();
            services.AddScoped<ILaptopValidator, LaptopValidator>();
            services.AddScoped<IConfigurationValidator, ConfigValidator>();

            services.AddScoped<IShoppingCartValidator, ShoppingCartValidator>();


            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            }
            );

            IMapper mapper = mappingConfig.CreateMapper();

            services.AddSingleton(mapper);

            services.AddMvc().AddJsonOptions(opts =>
            {
                opts.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "E-Commerce Api v1");
            });

            // var context = app.ApplicationServices.GetService<ECommerceApiContext>();
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ECommerceApiContext>();

                // Seed the database.
                AddTestData(context);
            }

           

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }

        private static void AddTestData(ECommerceApiContext eCommerceApiContext)
        {
            Configuration ramConfig = new Configuration()
            {
                configugurationEnumType=ConfigugurationEnum.RAM,
                Id = 1,
                Name = "8GB RAM",
                Price = 45.90M                
            };

            Configuration colourConfig = new Configuration()
            {
                configugurationEnumType= ConfigugurationEnum.Colour,
                Id = 2,
                Name = "Blue",
                Price = 30.90M
            };

            Configuration hddConfig = new Configuration()
            {
                configugurationEnumType=ConfigugurationEnum.HDD,
                Id = 3,
                Name = "500GB",
                Price = 30.90M
            };

            eCommerceApiContext.Configurations.Add(ramConfig);
            eCommerceApiContext.Configurations.Add(colourConfig);
            eCommerceApiContext.Configurations.Add(hddConfig);

            var laptop = new Laptop() { Id = 1, Name = "Dell", Price = 360.60M, Configuration = new List<Configuration> { 
                ramConfig,hddConfig
            } };

            var laptop2 = new Laptop() { Id = 2, Name = "Lenova", Price = 400.30M
            , Configuration = new List<Configuration> { ramConfig,colourConfig}
            };

            var shoppingCart = new ShoppingCart { Id = 1, Laptops = new List<Laptop> { laptop } };

            eCommerceApiContext.Laptops.Add(laptop);
            eCommerceApiContext.Laptops.Add(laptop2);
            eCommerceApiContext.ShoppingCarts.Add(shoppingCart);
            eCommerceApiContext.SaveChanges();

        }
    }
}
