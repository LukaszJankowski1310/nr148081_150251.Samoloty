using nr148081_150251.Samoloty.Web.Models.Company;
using System.ComponentModel.DataAnnotations;

namespace nr148081_150251.Samoloty.Web.Models.Plane
{
    public class PlaneViewModel
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public decimal MaximumSpeed { get; set; }
        public string CompanyName { get; set; }
        public PlaneTypeViewModel Type { get; set; }
    }
}
