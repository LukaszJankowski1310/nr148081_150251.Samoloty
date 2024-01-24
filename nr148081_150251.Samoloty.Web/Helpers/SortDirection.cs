using System.ComponentModel.DataAnnotations;

namespace nr148081_150251.Samoloty.Web.Helpers
{
    public enum SortDirection
    {
        [Display(Name = "Rosnąco")]
        Ascending,
        [Display(Name = "Malejąco")]
        Descending
    }
}
