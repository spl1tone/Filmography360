using Filmography360.DataBase.DbContextController;

namespace Filmography360;

public class Program
{
    public static void Main (string[] args)
    {
        //FakerInfo.FakerInfo faker = new();
        //faker.CreateData(100);
        Configuration(args);
    }

    private static void Configuration (string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllersWithViews();
        builder.Services.AddDbContext<MainDbContext>();
        builder.Services.AddRazorPages();

        var app = builder.Build();

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
               name: "default",
               pattern: "{controller=Home}/{action=indexDark}/{id?}");

        app.MapRazorPages();

        app.Run();
    }
}
