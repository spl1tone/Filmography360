using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Filmography360.Models.FilmModel;

public class Actor
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int Id { get; set; }
    public string FilmStarredIn { get; set; }
    public string FullName { get; set; }
    public string DateOfBirth { get; set; }
    public int Age { get; set; }
    public string Height { get; set; }
    public string Career { get; set; }
    public string Role { get; set; }
    public string Biography { get; set; }
    public string PictureUrl { get; set; }
    public int FilmInfoId { get; set; }

}
