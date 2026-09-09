namespace HmhLesson06lab
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews()
                .AddRazorOptions(options =>
                {
                    options.ViewLocationFormats.Add("/Views/HmhPartials/{0}.cshtml");
                    options.ViewLocationFormats.Add("/Views/HmhComponents/{1}/{0}.cshtml");
                    options.ViewLocationFormats.Add("/Views/HmhHome/{0}.cshtml");
                });

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/HmhHome/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=HmhHome}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
