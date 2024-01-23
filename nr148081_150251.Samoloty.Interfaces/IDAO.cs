using nr148081_150251.Samoloty.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace nr148081_150251.Samoloty.Interfaces
{
    public interface IDAO
    {
        IEnumerable<ICompany> GetCompanies();
        ICompany NewCompany();
        void SaveCompany(ICompany company);
        void DeleteCompany(ICompany company);

        IEnumerable<IPlane> GetPlanes();
        IPlane NewPlane();
        void SavePlane(IPlane plane);
        void DeletePlane(IPlane plane);
    }
}

