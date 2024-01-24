using System.ComponentModel.DataAnnotations;

namespace nr148081_150251.Samoloty.Web.Models.Company
{
    public class CompanyViewModel
    {
        public int Id { get; set; }

        //[Required(ErrorMessage = "Model is required")]
        public string? Name { get; set; }
        public int Year { get; set; }
    }
}
