using nr148081_150251.Samoloty.Core;

namespace nr148081_150251.Samoloty.Interfaces
{
    public interface IPlane
    {
        public int Id { get; set; } 
        public string Model { get; set; }
        public decimal MaximumSpeed { get; set; }
        public PlaneType Type { get; set; }
        public ICompany Company { get; set; }
    }
}