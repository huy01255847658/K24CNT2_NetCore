using HoangManhHuy2410900040_exam.Models;
using Microsoft.EntityFrameworkCore;

namespace HoangManhHuy2410900040_exam
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //lấy chuỗi kết nối từ appsettings.json
            var hmhConnection = builder.Configuration.GetConnectionString("HmhEmployee2410900040");
            builder.Services.AddDbContext<HmhEmployee2410900040DbSqlContext>(x=>x.UseSqlServer(hmhConnection));
            
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
