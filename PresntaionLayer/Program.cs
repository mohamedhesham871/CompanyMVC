using Microsoft.EntityFrameworkCore;
using ComapnyMVCBussinesLogic.services;
using MVCCompanyDataAccess.Repo;
namespace PresntaionLayer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<MVCCompanyDataAccess.Contexts.AppContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
                //options.UseSqlServer(builder.configuration["ConnectionStrings:DefaultConnection"]);
            });
            //make Dependency Injection for DepartmentRepo
            builder.Services.AddScoped<IDepartmentRepo,DepartmentRepo>();
            //make Dependency Injection for DepartmentServices
            builder.Services.AddScoped<IDepartmentServices, DepartmentServices>();
            #endregion
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
