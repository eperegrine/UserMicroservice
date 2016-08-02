using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore;

using UserMicroservice.API.Database;
using UserMicroservice.API.Requests;
using UserMicroservice.API.Database.Repositories;
using UserMicroservice.API.Requests.Queries.Permissions;
using UserMicroservice.API.Requests.Handlers.Permissions;
using UserMicroservice.Data.Transfer.ViewModels.Permissions;
using UserMicroservice.API.Requests.Queries.Users;
using UserMicroservice.API.Requests.Handlers.Users;
using UserMicroservice.Data.Transfer.ViewModels.User;
using Newtonsoft.Json;

namespace UserMicroservice.API
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddEntityFramework().AddDbContext<AppDbContext>(
                options => options.UseSqlServer(AppDbContextFactory.GetConnectionString())    
            );

            services.AddSingleton<AppDbContextFactory>();

            services.AddSingleton<UserRepository>();
            services.AddSingleton<PermissionRepository>();

            services.AddTransient<IQueryHandler<GetPermissionsQuery, PermissionListViewModel>, GetAllPermissionsHandler>();

            services.AddTransient<IQueryHandler<GetUsersQuery, UserListViewModel>, GetUsersHandler>();

            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc();
        }
    }
}
