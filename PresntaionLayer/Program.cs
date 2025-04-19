using Microsoft.EntityFrameworkCore;
using MVCCompanyDataAccess.Repo.ClassRepo;
using MVCCompanyDataAccess.Repo.InterfaceRepo;
using ComapnyMVCBussinesLogic.services.Class;
using ComapnyMVCBussinesLogic.services.Interfaces;
using ComapnyMVCBussinesLogic.Profiles;
using Microsoft.AspNetCore.Mvc;
namespace PresntaionLayer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region Add services to the container.
            builder.Services.AddControllersWithViews(
                option => option.Filters.Add(new AutoValidateAntiforgeryTokenAttribute())
                );
            builder.Services.AddDbContext<MVCCompanyDataAccess.Contexts.AppContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
                //options.UseSqlServer(builder.configuration["ConnectionStrings:DefaultConnection"]);
            });
            //make Dependency Injection for DepartmentRepo
            builder.Services.AddScoped<IDepartmentRepo,DepartmentRepo>();
            //make Dependency Injection for DepartmentServices
            builder.Services.AddScoped<IDepartmentServices, DepartmentServices>();
            builder.Services.AddScoped<IEmployeeRepo, EmployeeRepo>();
            builder.Services.AddScoped<IEmployeeServices, EmployeeServices>();


           //builder.Services.AddAutoMapper(typeof(EmployeeProfile).Assembly);// All profiles
            builder.Services.AddAutoMapper(p=>p.AddProfile(new EmployeeProfile()));
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
