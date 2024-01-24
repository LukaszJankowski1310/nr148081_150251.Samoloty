using System;

using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using nr148081_150251.Samoloty.Core;
using nr148081_150251.Samoloty.Interfaces;

namespace nr148081_150251.Samoloty.DAOMock
{
    public class Plane : IPlane
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public decimal MaximumSpeed { get; set; }
        public PlaneType Type { get; set; }
        public ICompany Company { get; set; }
   

    }

}