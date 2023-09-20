using Bogus;
using Filmography360.Models.FilmModel;
using System.Globalization;

namespace Filmography360.FakerInfo;

public class FakerInfo
{
    public void CreateData ()
    {
        for (int i = 1; i <= 5; i++) {
            var faker = new Faker<FilmInfo>()
             .RuleFor(f => f.Id, f => i)
             .RuleFor(f => f.Name, f => f.Commerce.ProductName())
             .RuleFor(f => f.Genre, f => f.Commerce.Categories(1)[0])
             .RuleFor(f => f.Description, f => f.Lorem.Sentence(15))
             .RuleFor(f => f.Facts, f => f.Lorem.Paragraph(4))
             .RuleFor(f => f.ReasonsToLook, f => f.Lorem.Paragraph(2))
             .RuleFor(f => f.Duration, f => FormatDuration(f.Date.Timespan()))
             .RuleFor(f => f.YearOfIssue, f => f.Date.Past(30).Year)
             .RuleFor(f => f.WorldPremiere, f => f.Date.Between(f.Date.Past(30), DateTime.Now).ToString("d MMMM yyyy", new CultureInfo("en-US"))) //question 1
             .RuleFor(f => f.Age, f => f.Random.Number(12, 18))
             .RuleFor(f => f.MPAA, f => f.PickRandom("G", "PG", "PG-13", "R"))
             .RuleFor(f => f.Budget, f => f.Finance.Amount(10000, 10000000).ToString("C", new CultureInfo("en-US")))
             .RuleFor(f => f.Rating, f => (float)Math.Round(f.Random.Float(1, 10), 2))
             .RuleFor(f => f.PictureUrl, f => f.Image.PicsumUrl());

            FilmInfo filmInfo = faker.Generate();

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
    string FormatDuration (TimeSpan time) => $"{time.Hours} hours {time.Minutes} minutes";
}
