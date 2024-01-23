using Microsoft.EntityFrameworkCore;
using nr148081_150251.Samoloty.Interfaces;


namespace nr148081_150251.Samoloty.DAOSql
{
    public class SqlDAO : IDAO
    {
        private Context _dbContext;
        public SqlDAO()
        {
           _dbContext = new Context();
            _dbContext.Database.EnsureCreated();
        }

        public void DeleteCompany(ICompany company)
        {
            _dbContext.Companies.Remove((Company) company);
        }

        public void DeletePlane(IPlane plane)
        {
            _dbContext.Planes.Remove((Plane)plane);
        }

        public IEnumerable<ICompany> GetCompanies()
        {
            return _dbContext.Companies;
        }

        public IEnumerable<IPlane> GetPlanes()
        {
            return _dbContext.Planes;
        }

        public ICompany NewCompany()
        {
            return new Company();
        }

        public IPlane NewPlane()
        {
            return new Plane();
        }

        public void SaveCompany(ICompany company)
        {
            _dbContext.Companies.Add((Company) company);
            _dbContext.SaveChanges();
        }

        public void SavePlane(IPlane plane)
        {
            _dbContext.Planes.Add((Plane) plane);
            _dbContext.SaveChanges();
        }
    }
}
