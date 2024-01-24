using System.ComponentModel.DataAnnotations;

namespace nr148081_150251.Samoloty.Web.Models.Plane
{
    public class PlaneEditViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Pole \"Model\" jest wymagane")]
        public string Model { get; set; }

        [RegularExpression(@"^\d*([\.,]?\d+)?$", ErrorMessage = "Podaj liczbę")]
        [Required(ErrorMessage = "Pole \"Maksymalna prędkość\" jest wymagane")]
        [Range(0.1, double.MaxValue, ErrorMessage = "Maksymalna prędkość musi być większa od 0")]
        public decimal MaximumSpeed { get; set; }

        public EntityViewModel Company { get; set; }
        public PlaneTypeViewModel Type { get; set; }
    }
}
