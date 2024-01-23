using nr148081_150251.Samoloty.Core;
using nr148081_150251.Samoloty.Interfaces;

namespace nr148081_150251.Samoloty.DAOMock
{
    public class MockDAO : IDAO
    {
        private List<ICompany> _companyList;
        private int idCompany = 0;
        private List<IPlane> _planeList;
        private int idPlane = 0;
        public MockDAO()
        {
            _companyList = new List<ICompany>()
            {
                new Company() {Name = "Name1", Year = 2001, Id = ++idCompany },
                new Company() {Name = "Name2", Year = 2011, Id = ++idCompany }
            };

            _planeList = new List<IPlane>()
            {
                new Plane {Model = "Model1", Company= _companyList[0], Type=PlaneType.Cargo, MaximumSpeed=500, Id=++idPlane },
                new Plane {Model = "Model2", Company= _companyList[0], Type=PlaneType.Passenger, MaximumSpeed=400, Id=++idPlane},
                new Plane {Model = "Model3", Company= _companyList[1], Type=PlaneType.Private, MaximumSpeed=300 , Id=++idPlane},
            };
        }


        public void DeleteCompany(ICompany company)
        {
            _companyList.Remove(company);
        }

        public void DeletePlane(IPlane plane)
        {
            _planeList.Remove(plane);
        }

        public IEnumerable<ICompany> GetCompanies()
        {
            return _companyList;
        }

        public IEnumerable<IPlane> GetPlanes()
        {
            return _planeList;
        }

        public ICompany NewCompany()
        {
            return new Company() { Id = ++idCompany };
        }

        public IPlane NewPlane()
        {
            return new Plane() { Id = ++idPlane };
        }

        public void SaveCompany(ICompany company)
        {
            _companyList.Add(company);
        }

        public void SavePlane(IPlane plane)
        {
            _planeList.Add(plane);
        }
    }
}