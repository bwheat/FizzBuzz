
using FizzBuzz.Configuration;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.AspNetCore.Server.IISIntegration;
using FizzBuzz.Repositories;
using Asp.Versioning.ApiExplorer;
using Asp.Versioning;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace FizzBuzz
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private readonly string corsPolicyName = "DefaultCORS";

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddHttpContextAccessor();
            var apiVersioningBuilder = services.AddApiVersioning(opt =>
            {
                opt.AssumeDefaultVersionWhenUnspecified = true;
                opt.DefaultApiVersion = new ApiVersion(1, 0);
                opt.ReportApiVersions = true;
            });

            apiVersioningBuilder.AddApiExplorer(setup =>
            {
                setup.GroupNameFormat = "'v'VVV";
                setup.SubstituteApiVersionInUrl = true;
            });

            services.AddSwaggerGen();
            services.ConfigureOptions<SwaggerConfiguration>();

            services.AddAuthentication(IISDefaults.AuthenticationScheme);

            services.AddScoped<IFizzBuzzRepository, FizzBuzzRepository>();
            services.AddScoped<IPersonRepository, PersonRepository>();
            var connectionString = Configuration.GetConnectionString("CapServices");
            //services.AddDbContext<CapServicesDbContext>(options => options.Options.(connectionString));

            services.AddDbContext<CapServicesDbContext>(ServiceLifetime.Scoped);

            // services.AddDbContext<CapServicesDbContext>(options =>
            //     options.Options.ContextType());

            #region Cors
            // services.AddCorsConfigurations(corsPolicyName, 
            //     Configuration.GetSection("CorsAppUi").GetChildren().Select(x => x.Value).ToArray());
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
            if (!env.IsProduction())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();

                app.UseSwaggerUI(options =>
                {
                    foreach (var description in provider.ApiVersionDescriptions)
                    {
                        options.SwaggerEndpoint(
                            $"../swagger/{description.GroupName}/swagger.json",
                            description.GroupName.ToUpperInvariant());
                    }
                });
                RewriteOptions option = new RewriteOptions();

                option.AddRedirect("^$", "swagger");

                app.UseRewriter(option);
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(corsPolicyName);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
