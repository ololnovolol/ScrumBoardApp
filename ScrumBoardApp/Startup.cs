using AutoMapper;
using BLL.Models;
using DAL.EF;
using DAL.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ScrumBoardApp.Models;
using ScrumBoardApp.Models.Authorization;
using ScrumBoardApp.Models.Column;

namespace ScrumBoardApp
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureDatabase(services);
            services.AddControllersWithViews();
            //services.RegisterBusinessLogicServices();
        }

        protected virtual void ConfigureDatabase(IServiceCollection services)
        {
            // TODO: read connection string from settings.json

            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connectionString));

            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationContext>();

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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseStaticFiles();
            app.UseDefaultFiles();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllers();
                endpoints.MapFallbackToFile("/index.html");
            });

            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<UserModel, UserBL>(MemberList.Source);
                cfg.CreateMap<UserBL, User>(MemberList.Destination);

                cfg.CreateMap<BoardModel, BoardBL>(MemberList.None);
                cfg.CreateMap<BoardBL, Board>(MemberList.None);

                cfg.CreateMap<ColumnModel, ColumnBL>(MemberList.None);
                cfg.CreateMap<ColumnBL, Column>(MemberList.None);

                cfg.CreateMap<TaskModel, TaskBL>(MemberList.None);
                cfg.CreateMap<TaskBL, Taska>(MemberList.None);
            });
        }
    }
}
