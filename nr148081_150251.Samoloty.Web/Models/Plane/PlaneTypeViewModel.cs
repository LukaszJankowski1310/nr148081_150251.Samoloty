using System.ComponentModel.DataAnnotations;

namespace nr148081_150251.Samoloty.Web.Models.Plane
{
    public enum PlaneTypeViewModel
    {
        [Display(Name = "Samolot Pasażerski")]
        Passenger,
        [Display(Name = "Samolot Cargo")]
        Cargo,
        [Display(Name = "Samolot Wojskowy")]
        Military,
        [Display(Name = "Samolot Prywatny")]
        Private
    }

}
