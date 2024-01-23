using nr148081_150251.Samoloty.Interfaces;

namespace nr148081_150251.Samoloty.DAOMock
{
    public class MockDAO : IDAO
    {

        public void DeleteCompany(ICompany company)
        {
            throw new NotImplementedException();
        }

        public void DeletePlane(IPlane plane)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ICompany> GetCompanies()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IPlane> GetPlanes()
        {
            throw new NotImplementedException();
        }

        public ICompany NewCompany()
        {
            throw new NotImplementedException();
        }

        public IPlane NewPlane()
        {
            throw new NotImplementedException();
        }

        public void SaveCompany(ICompany company)
        {
            throw new NotImplementedException();
        }

        public void SavePlane(IPlane plane)
        {
            throw new NotImplementedException();
        }
    }
}