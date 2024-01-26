using System.ComponentModel.DataAnnotations;

namespace nr148081_150251.Samoloty.Web.Models.Company
{
    public class CompanyViewModel
    {
        public int Id { 
            get; 
            set; 
        }

        [Display(Name = "Nazwa")]
        [Required(ErrorMessage = "Pole 'Nazwa' jest wymagane.")]
        [StringLength(100, ErrorMessage = "Pole 'Nazwa' nie może być dłuższe niż 100 znaków.")]
        public string Name { get; set; } = "";

        [Display(Name = "Rok założenia")]
        [Required(ErrorMessage = "Pole 'Rok założenia' jest wymagane.")]
        [Range(1800, 2100, ErrorMessage = "Podaj prawidłowy rok założenia.")]
        public int Year { get; set; }

        [Display(Name = "Opis")]
        [StringLength(500, ErrorMessage = "Pole 'Opis' nie może być dłuższe niż 500 znaków.")]
        public string? Description { get; set; }
    }
}
