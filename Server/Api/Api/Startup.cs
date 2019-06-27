namespace Api
{
    using BLL;

    using DAL;
    using DAL.Abstractions;
    using DAL.MemoryRepository;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public class Startup
    {
        private readonly string _policyName = "custom_origins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(_policyName);

            app.UseMvc();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(
                options =>
                    {
                        options.AddPolicy(
                            _policyName,
                            builder =>
                                {
                                    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                                });
                    });

            services.AddSingleton<IDataContext, MemoryContext>();
            services.AddTransient<IEntitiesRepository, EntitiesRepository>();
            services.AddTransient<IEntitiesService, EntitiesService>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.Configure<ApiBehaviorOptions>(options =>
                {
                    options.SuppressModelStateInvalidFilter = true;
                });
        }
    }
}