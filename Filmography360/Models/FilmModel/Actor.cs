namespace Filmography360.Models.FilmModel;

public class Actor
{
    public int Id { get; set; }
    public string FilmStarredIn { get; set; }
    public string FullName { get; set; }
    public string DateOfBirth { get; set; }
    public int Age { get; set; }
    public string height { get; set; }
    public string Career { get; set; }
    public string Role { get; set; }
    public string Biography { get; set; }
    public string PictureUrl { get; set; }

    public List<FilmInfo>? Filmography { get; set; }
}
