using nr148081_150251.Samoloty.Interfaces;

namespace nr148081_150251.Samoloty.DAOMock
{
    public class Company : ICompany
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
    }
}