using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Entities.Interfaces;
using WebAPI.Interfaces;
using WebAPI.Services;
using Entities.Repositories;

namespace WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public IRepositoryContext RepositoryContext { get; }

        private const string AngularCorsPolicy = "_angularCorsPolicy";

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IRepositoryContext, RepositoryContext>(provider => new RepositoryContext());

            services.AddSingleton(Configuration);
            services.AddScoped<INoteService, NoteService>();
            services.AddScoped<INoteRepository, NoteRepository>();

            services.AddCors(options =>
            {
                options.AddPolicy(name: AngularCorsPolicy, builder =>
                {
                    builder
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyOrigin();
                });
            });

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(AngularCorsPolicy);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
