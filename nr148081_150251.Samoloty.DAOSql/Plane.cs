using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using nr148081_150251.Samoloty.Core;
using nr148081_150251.Samoloty.Interfaces;

namespace nr148081_150251.Samoloty.DAOSql
{
    public class Plane : IPlane
    {
        public Guid Id { get; set; }
        public string Model { get; set; }
        public double MaximumSpeed { get; set; }
        public PlaneType Type { get; set; }
        public Company Company { get; set; }
        ICompany IPlane.Company { get => Company; set => Company = (Company)value ; }

    }

}