﻿using Microsoft.EntityFrameworkCore;
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
            var plane = _dbContext.Planes.FirstOrDefault(x => x.Company.Id == company.Id);
            if (plane != null)
            {
                throw new Exception("Nie można usunąc, ponieważ istnieje samolot wyprodukowany przez tego producenta");
            }

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

        public ICompany? GetCompany(int id)
        {
            return _dbContext.Companies.Find(id);
        }

        public IPlane? GetPlane(int id)
        {
            return _dbContext.Planes.Find(id);
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
            if (GetCompany(company.Id) == null)
            {
                _dbContext.Companies.Add((Company) company);
            }
        }

        public void SavePlane(IPlane plane)
        {
            if (GetPlane(plane.Id) == null)
            {
                _dbContext.Planes.Add((Plane) plane);
            }

        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }
    }
}
