using nr148081_150251.Samoloty.Web.Models.Company;
using System.ComponentModel.DataAnnotations;

namespace nr148081_150251.Samoloty.Web.Models.Plane
{
    public class PlaneViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Model")]
        public string Model { get; set; } = "";

        [Display(Name = "Maksymalna prędkośc")]
        public decimal MaximumSpeed { get; set; }
        [Display(Name = "Nazwa firmy")]
        public string CompanyName { get; set; } = "";

        [Display(Name = "Typ")]
        public PlaneTypeViewModel Type { get; set; }
    }
}
