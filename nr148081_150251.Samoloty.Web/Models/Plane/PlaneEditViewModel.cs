using System.ComponentModel.DataAnnotations;

namespace nr148081_150251.Samoloty.Web.Models.Plane
{
    public class PlaneEditViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Model")]
        [Required(ErrorMessage = "Pole \"Model\" jest wymagane")]
        public string Model { get; set; } = "";

        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "Nie prawidłowy format")]
        [Required(ErrorMessage = "Pole \"Maksymalna prędkość\" jest wymagane")]
        [Range(0, double.MaxValue, ErrorMessage = "Maksymalna prędkość musi być większa od 0")]
        [Display(Name = "Maksymalna prędkośc")]
        public decimal MaximumSpeed { get; set; }

        [Required(ErrorMessage = "Pole \"Nazwa firmy\" jest wymagane")]
        [Display(Name = "Nazwa firmy")]
        public EntityViewModel Company { get; set; }

        [Required(ErrorMessage = "Pole \"Typ\" jest wymagane")]
        [Display(Name = "Typ")]
        public PlaneTypeViewModel Type { get; set; }
    }
}
