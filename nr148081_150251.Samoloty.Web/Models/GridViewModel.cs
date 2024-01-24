using nr148081_150251.Samoloty.Web.Helpers;

namespace nr148081_150251.Samoloty.Web.Models
{
    public class GridViewModel<T> where T : class
    {
        public IEnumerable<T> Items { get; set; }

        public SortDirection SortDirection { get; set; }

        public string SortField { get; set; }

    }
}
