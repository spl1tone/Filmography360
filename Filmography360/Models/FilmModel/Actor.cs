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

    public Actor ()
    {

    }

    public Actor (int id, string filmStarredIn, string fullName, string dateOfBirth, int age, string height, string career, string role, string biography, string pictureUrl)
    {
        Id = id;
        FilmStarredIn = filmStarredIn;
        FullName = fullName;
        DateOfBirth = dateOfBirth;
        Age = age;
        this.height = height;
        Career = career;
        Role = role;
        Biography = biography;
        PictureUrl = pictureUrl;
    }

}
