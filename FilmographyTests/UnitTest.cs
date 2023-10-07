using Filmography360;
using Filmography360.FakerInfo;
using Filmography360.Models.FilmModel;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace FilmographyTests;

public class UnitTest
{
    [Fact]
    public void TestingFilmInfoClass ()
    {
        var film = new FilmInfo() {
            Id = 1,
            Name = "FilmName",
            Rating = 3.5f,
            PictureUrl = "SomeUrl"
        };

        Assert.Equal(1, film.Id);
        Assert.Equal("FilmName", film.Name);
        Assert.Equal(3.5f, film.Rating);
        Assert.Equal("SomeUrl", film.PictureUrl);
    }

    [Fact]
    public void TestingActorClass ()
    {
        var actor = new Actor() {
            Id = 1,
            FullName = "ActorName",
            Age = 20,
            PictureUrl = "SomeUrl"
        };

        Assert.Equal(1, actor.Id);
        Assert.Equal("ActorName", actor.FullName);
        Assert.Equal(20, actor.Age);
        Assert.Equal("SomeUrl", actor.PictureUrl);
    }

    [Fact]
    public void TestingFakerInfo ()
    {
        var fakerInfo = new FakerInfo();
        fakerInfo.CreateData(1);
        var filmItems = FakerInfo.filmInfosForTest;
        var actorItems = FakerInfo.actorsForTest;

        Assert.Equal(1, filmItems[0].Id);
        Assert.Equal(1, actorItems[0].Id);
    }

}

public class HomeControllerTest : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public HomeControllerTest (WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task IndexDarkReturnsView ()
    {
        var client = _factory.CreateClient();

        var response = await client.GetAsync("/Home/indexDark");

        response.EnsureSuccessStatusCode();

        Assert.Equal("text/html; charset=utf-8", response.Content.Headers.ContentType.ToString());
    }

    [Fact]
    public async Task FilmInfoDark_ReturnsView ()
    {
        var client = _factory.CreateClient();

        var fakerInfo = new FakerInfo();

        fakerInfo.CreateData(1);
        var filmItems = FakerInfo.filmInfosForTest;

        var response = await client.GetAsync($"/Home/filmInfoDark/{filmItems[0].Id}");

        response.EnsureSuccessStatusCode();

        Assert.Equal("text/html; charset=utf-8", response.Content.Headers.ContentType.ToString());
    }

    [Fact]
    public async Task ActorInfoDark_ReturnsView ()
    {
        var client = _factory.CreateClient();

        var fakerInfo = new FakerInfo();

        fakerInfo.CreateData(1);
        var actorItems = FakerInfo.actorsForTest;

        var response = await client.GetAsync($"/Home/actorInfoDark/{actorItems[0].Id}");

        response.EnsureSuccessStatusCode();

        Assert.Equal("text/html; charset=utf-8", response.Content.Headers.ContentType.ToString());
    }

    [Fact]
    public async Task AboutMeDark_ReturnsView ()
    {
        var client = _factory.CreateClient();

        var response = await client.GetAsync("/Home/aboutMeDark");

        response.EnsureSuccessStatusCode();

        Assert.Equal("text/html; charset=utf-8", response.Content.Headers.ContentType.ToString());
    }
}