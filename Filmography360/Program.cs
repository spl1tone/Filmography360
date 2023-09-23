namespace Filmography360;

public class Program
{
	public static void Main (string[] args)
	{
		FakerInfo.FakerInfo faker = new();
		faker.CreateData(5);
		Configuration(args);
	}

	private static void Configuration (string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);

		builder.Services.AddControllersWithViews();

		var app = builder.Build();

		app.UseHttpsRedirection();
		app.UseStaticFiles();

		app.UseRouting();

		app.UseAuthorization();

		app.MapControllerRoute(
			   name: "default",
			   pattern: "{controller=Home}/{action=MainPage}/{id?}");

		app.Run();
	}
}
