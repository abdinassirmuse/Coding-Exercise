using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

//Custom Modules
using CodingAssessmentDAL;
using CodingAssessmentDAL.Models;
using CodingAssessmentWebAPI;

namespace CodingAssessmentWebAPI
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

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>

            {

                builder.AllowAnyOrigin()

                       .AllowAnyMethod()

                       .AllowAnyHeader();

            }));

            var mappingConfig = new MapperConfiguration(mc =>

            {

                mc.AddProfile(new CoddingAssessmentMapper());

            });

            IMapper mapper = mappingConfig.CreateMapper();

            services.AddSingleton(mapper);

            services.AddSingleton<Repository>(new Repository(new CodingAssessmentDBContext(new DbContextOptions<CodingAssessmentDBContext>())));



        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)

        {

            if (env.IsDevelopment())

            {

                app.UseDeveloperExceptionPage();

            }

            else

            {

                app.UseHsts();

            }

            app.UseCors("MyPolicy");

            app.UseHttpsRedirection();

            app.UseMvc();

        }

    }

}
