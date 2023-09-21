using Bogus;
using Filmography360.Models.FilmModel;
using System.Globalization;

namespace Filmography360.FakerInfo;

public class FakerInfo
{
    public void CreateData ()
    {
        for (int i = 1; i <= 10; i++) {
            var faker = new Faker<FilmInfo>()
             .RuleFor(f => f.Id, f => i)
             .RuleFor(f => f.Name, f => f.Commerce.ProductName())
             .RuleFor(f => f.Genre, f => f.Commerce.Categories(1)[0])
             .RuleFor(f => f.Description, f => f.Lorem.Sentence(15))
             .RuleFor(f => f.Facts, f => f.Lorem.Paragraph(4))
             .RuleFor(f => f.ReasonsToLook, f => f.Lorem.Paragraph(3))
             .RuleFor(f => f.Duration, f => FormatDuration(f.Date.Timespan()))
             .RuleFor(f => f.YearOfIssue, f => f.Date.Past(30).Year)
             .RuleFor(f => f.WorldPremiere, (faker, filminfo) => faker.Date.Between(new DateTime(filminfo.YearOfIssue, 1, 1), faker.Date.Past(30)).ToString("d MMMM yyyy", new CultureInfo("en-US"))) //question 1
             .RuleFor(f => f.Age, f => f.Random.Number(12, 18))
             .RuleFor(f => f.MPAA, f => f.PickRandom("G", "PG", "PG-13", "R"))
             .RuleFor(f => f.Budget, f => f.Finance.Amount(10000, 10000000).ToString("C", new CultureInfo("en-US")))
             .RuleFor(f => f.Rating, f => (float)Math.Round(f.Random.Float(1, 10), 2))
             .RuleFor(f => f.PictureUrl, f => f.Image.PicsumUrl());

            var filmInfo = faker.Generate();

            //Add Actors
            var random = new Random();
            var actorsCount = random.Next(1, 10);
            for (int j = 1; j <= actorsCount; i++) {
                AddActors(filmInfo.Name);
            }


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

        }
    }

    public void AddActors (string filmName)
    {
        var faker = new Faker<Actor>()
            .RuleFor(f => f.Id, f => f.UniqueIndex)
            .RuleFor(f => f.FilmStarredIn, f => f.Random.Words())
            .RuleFor(f => f.FullName, f => f.Name.FullName())
            // .RuleFor(f => f.DateOfBirth, f => f.Date.Past(30))
            .RuleFor(f => f.Age, f => f.Random.Int(20, 80))
            //   .RuleFor(f => f.height, f => f.Person.Height.ToString())
            .RuleFor(f => f.Career, f => f.Random.Words())
            .RuleFor(f => f.Role, f => f.Random.Words())
            .RuleFor(f => f.Biography, f => f.Lorem.Paragraph())
            .RuleFor(f => f.PictureUrl, f => f.Internet.Url());


    }

    string FormatDuration (TimeSpan time) => $"{time.Hours} hours {time.Minutes} minutes";
}
