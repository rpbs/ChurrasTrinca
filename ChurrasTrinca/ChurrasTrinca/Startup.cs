using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using Core.Commands;
using Core.Interface;
using Core.Mapper;
using Core.Model;
using Core.Queries;
using Infra;
using Infra.Repositories;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;
using System.IO;
using System.Reflection;

namespace ChurrasTrinca
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ChurrasTrinca", Version = "v1" });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            services.AddDbContext<ChurrasDbContext>(options =>
                        options.UseSqlServer("Server=localhost;Initial Catalog=ChurrasTrinca;Persist Security Info=True;User ID=sa;Password=Sample123$;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;"),
                        ServiceLifetime.Scoped);

            var autoMapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new CoreProfile());
            });

            var mapper = autoMapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            var assembly = Assembly.GetExecutingAssembly();

            services.AddAutoMapper(assembly);
            
            services.AddMediatR(typeof(ChurrascoCommand).GetTypeInfo().Assembly);

            //services.AddMediatR(Assembly.GetExecutingAssembly());

            //services.AddMediatR(typeof(Startup).GetTypeInfo().Assembly);

            services.AddScoped<IChurrascoRepository, ChurrascoRepository>();
            services.AddScoped<IParticipanteRepository, ParticipanteRepository>();

            var builder = new ContainerBuilder();

            builder.Populate(services);

            var webAssembly = Assembly.GetExecutingAssembly();

            var container = builder.Build();

            return new AutofacServiceProvider(container);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ChurrasTrinca v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Financeiro API V1 - " + env.EnvironmentName);
                c.RoutePrefix = "";
                c.DocExpansion(DocExpansion.None);
            });

        }
    }
}
