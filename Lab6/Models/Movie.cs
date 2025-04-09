using System.ComponentModel.DataAnnotations;

namespace Lab5.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Tytuł filmu nie może być pusty")]
        [MaxLength(50, ErrorMessage = "Tytuł filmu może mieć co najwyżej 50 znaków")]
        public string Title { get; set; }
        [UIHint("LongText")]
        [Required(ErrorMessage = "Opis filmu nie może być pusty")]
        public string Description { get; set; }
        [UIHint("Stars")]
        [Required(ErrorMessage = "Podaj ocenę filmu")]
        [Range(1, 5, ErrorMessage = "Ocena filmu musi być liczbą pomiędzy 1 a 5")]
        public int Rating { get; set; }
        public string? TrailerLink { get; set;}
        public Genre Genre { get; set; }
    }
}
