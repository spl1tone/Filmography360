namespace Filmography360.Models.FilmModel;

public class FilmInfo
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Genre { get; set; }
    public string Description { get; set; }
    public string Facts { get; set; }
    public string ReasonsToLook { get; set; }
    public string Duration { get; set; }
    public int YearOfIssue { get; set; }
    public string WorldPremiere { get; set; }
    public int Age { get; set; }
    public string MPAA { get; set; }
    public string Budget { get; set; }
    public float Rating { get; set; }
    public string PictureUrl { get; set; }

    public List<Actor> Actors { get; set; }
}
