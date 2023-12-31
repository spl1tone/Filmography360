﻿using Bogus;
using Filmography360.Models.FilmModel;
using System.Globalization;
using System.Net;
using db = Filmography360.DataBase.DbContextController.MainDbContext;

namespace Filmography360.FakerInfo;

public class FakerInfo
{

    static Random random = new Random();
    static int ActorId = 1;
    static string[] MPAAS = { "G", "PG", "PG-13", "R" };
    static string[] Roles = { "Actor", "Director", "Producer", "Screenwriter", "Cinematographer", "Film Editor", "Costume Designer", "Makeup Artist", "Stunt Performer", "Set Designer", "Composer", "Production Assistant", "Casting Director" };

    public static List<FilmInfo> filmInfosForTest = new();
    public static List<Actor> actorsForTest = new();

    public void CreateData (int filmCount)
    {
        var _db = new db();

        if (filmCount <= 0) throw new Exception("filmCount must be > 0 ");



        for (int i = 1; i <= filmCount; i++) {
            var faker = new Faker<FilmInfo>()
             .RuleFor(f => f.Id, f => i)
             .RuleFor(f => f.Name, f => NameSubstring(f.Commerce.ProductName()))
             .RuleFor(f => f.Genre, f => RandomCategories(f.Commerce.Categories(random.Next(1, 4))))
             .RuleFor(f => f.Description, f => f.Lorem.Sentence(15))
             .RuleFor(f => f.Facts, f => f.Lorem.Paragraph(4))
             .RuleFor(f => f.ReasonsToLook, f => f.Lorem.Paragraph(3))
             .RuleFor(f => f.Duration, f => FormatDuration(f.Date.Timespan()))
             .RuleFor(f => f.YearOfIssue, f => f.Date.Past(30).Year)
             .RuleFor(f => f.WorldPremiere, (faker, filminfo) => faker.Date.Between(new DateTime(filminfo.YearOfIssue, 1, 1), faker.Date.Past(30)).ToString("d MMMM yyyy", new CultureInfo("en-US")))
             .RuleFor(f => f.Age, f => f.Random.Number(12, 18))
             .RuleFor(f => f.MPAA, f => f.PickRandom(MPAAS))
             .RuleFor(f => f.Budget, f => f.Finance.Amount(10000, 10000000).ToString("C0", new CultureInfo("en-US")))
             .RuleFor(f => f.Rating, f => (float)Math.Round(f.Random.Float(1, 10), 2))
             .RuleFor(f => f.PictureUrl, f => CheckForInvalidPicture(f.Image.PicsumUrl()));

            var filmInfo = faker.Generate();

            Console.WriteLine($"Id: {filmInfo.Id}");
            Console.WriteLine($"Name: {filmInfo.Name}");
            Console.WriteLine($"Genre: {filmInfo.Genre}");
            Console.WriteLine($"Description: {filmInfo.Description}");
            Console.WriteLine($"Facts: {filmInfo.Facts}");
            Console.WriteLine($"ReasonsToLook: {filmInfo.ReasonsToLook}");
            Console.WriteLine($"Duration: {filmInfo.Duration}");
            Console.WriteLine($"YearOfIssue: {filmInfo.YearOfIssue}");
            Console.WriteLine($"WorldPremiere: {filmInfo.WorldPremiere}");
            Console.WriteLine($"Age: {filmInfo.Age}");
            Console.WriteLine($"MPAA: {filmInfo.MPAA}");
            Console.WriteLine($"Budget: {filmInfo.Budget}");
            Console.WriteLine($"Rating: {filmInfo.Rating}");
            Console.WriteLine($"PictureUrl: {filmInfo.PictureUrl}");
            Console.WriteLine(new string('-', 30));
            Console.WriteLine("\n");

            //Adding class to the database
            //_db.FilmInfos.Add(filmInfo);
            //_db.SaveChanges();

            filmInfosForTest.Add(filmInfo);

            //Add Actors
            var actorsCount = random.Next(4, 11);
            for (int j = 1; j <= actorsCount; j++) {
                AddActors(filmInfo.Name, i);
                ActorId++;
            }
        }

    }

    public string NameSubstring (string text)
    {
        if (text.Length > 12) {
            text = text.Substring(0, 12);
        }
        return text;
    }

    public string CheckForInvalidPicture (string pictureUrl)
    {
        try {
            using (var client = new WebClient()) {
                string html = client.DownloadString(pictureUrl);
            }
        }
        catch {
            return "https://upload.wikimedia.org/wikipedia/commons/thumb/4/46/Question_mark_%28black%29.svg/800px-Question_mark_%28black%29.svg.png";
        }

        return pictureUrl;
    }

    public void AddActors (string filmName, int filmId)
    {
        var _db = new db();
        Console.WriteLine(new string('-', 30));
        Console.WriteLine("\n");
        var faker = new Faker<Actor>()
            .RuleFor(f => f.Id, f => ActorId)
            .RuleFor(f => f.FilmStarredIn, f => filmName)
            .RuleFor(f => f.FullName, f => NameSubstring(f.Name.FullName()))
            .RuleFor(f => f.DateOfBirth, f => f.Date.Past(30).ToString("d MMMM yyyy", new CultureInfo("en-US")))
            .RuleFor(f => f.Age, f => f.Random.Int(20, 80))
            .RuleFor(f => f.Height, f => f.Random.Number(150, 210) + " cm")
            .RuleFor(f => f.Career, f => RandomCategories(f.PickRandom(Roles, random.Next(1, 5)).ToArray()))
            .RuleFor(f => f.Role, f => f.PickRandom(Roles))
            .RuleFor(f => f.Biography, f => f.Lorem.Paragraph())
            .RuleFor(f => f.PictureUrl, f => CheckForInvalidPicture(f.Image.PicsumUrl()))
            .RuleFor(f => f.FilmInfoId, f => filmId);

        var actor = faker.Generate();

        Console.WriteLine($"Id: {actor.Id}");
        Console.WriteLine($"FilmStarredIn: {actor.FilmStarredIn}");
        Console.WriteLine($"FullName: {actor.FullName}");
        Console.WriteLine($"DateOfBirth: {actor.DateOfBirth}");
        Console.WriteLine($"Age: {actor.Age}");
        Console.WriteLine($"Height: {actor.Height}");
        Console.WriteLine($"Career: {actor.Career}");
        Console.WriteLine($"Role: {actor.Role}");
        Console.WriteLine($"Biography: {actor.Biography}");
        Console.WriteLine($"PictureUrl: {actor.PictureUrl}");
        Console.WriteLine($"FilmInfoId: {actor.FilmInfoId}");
        Console.WriteLine(new string('-', 30));
        Console.WriteLine("\n");

        actorsForTest.Add(actor);

        //Adding class to the database
        //_db.Actors.Add(actor);
        //_db.SaveChanges();


    }

    string FormatDuration (TimeSpan time) => $"{time.Hours} hours {time.Minutes} minutes";
    string RandomCategories (string[] items)
    {
        var text = string.Empty;
        for (int i = 0; i < items.Length; i++) text = text + ", " + items[i];
        return text.Length > 2 ? text.Substring(2) : text;
    }
}
