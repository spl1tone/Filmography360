using Filmography360.Models.FilmModel;
using Microsoft.EntityFrameworkCore;

namespace Filmography360.DataBase.DbContextController;

public class MainDbContext : DbContext
{
    public DbSet<FilmInfo> FilmInfos { get; set; }
    public DbSet<Actor> Actors { get; set; }

    protected override void OnConfiguring (DbContextOptionsBuilder _options)
    {
        _options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=FilmDB;Trusted_Connection=True;");
    }

}
