using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WMS.API.MappingConfig;
using WMS.API.Validators.Product;
using WMS.DataAccess.MSSQL.Repositories;
using WMS.DataAccess.Repositories;
using WMS.Service.Definitions.Dtos;
using WMS.Service.Definitions.Services;
using WMS.Service.Implementations.Services;
using System.Data.SqlClient;
using Microsoft.OpenApi.Models;
using WMS.DataAccess;
using WMS.DataAccess.MSSQL;
using WMS.DataAccess.MSSQL.Context;

namespace WMS.API
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
            //resolve dependencies
            services.AddScoped<IUnitOfWork, SqlUnitOfWork>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderService, OrderService>();
            //config mapper
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            var mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
            //Validator
            ValidatorOptions.LanguageManager.Culture = new System.Globalization.CultureInfo("fa");// = new PersianLanguage();
            services.AddSingleton<IValidator<ProductDto>, ProductValidator>();
            //Config EF
            services.AddScoped<WmsDbContext>(_ => new WmsDbContext(Configuration.GetConnectionString("DefaultConnection")));
            //config swagger
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo { Title = "WMS Api", Version = "v1" }); });
            //Other
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "WMS Api");
                c.RoutePrefix = string.Empty;
            });
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
