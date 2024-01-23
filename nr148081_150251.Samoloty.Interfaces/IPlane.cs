using nr148081_150251.Samoloty.Core;

namespace nr148081_150251.Samoloty.Interfaces
{
    public interface IPlane
    {
        public Guid Id { get; set; }
        public string Model { get; set; }
        public double MaximumSpeed { get; set; }
        public PlaneType Type { get; set; }
        public ICompany Company { get; set; }
    }
}