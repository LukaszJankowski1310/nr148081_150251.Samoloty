using System.Numerics;
using System.Reflection;
using System.Windows.Input;
using nr148081_150251.Samoloty.Interfaces;

namespace nr148081_150251.Samoloty.BL
{
    public class Logic
    {
        private IDAO dao;

        public Logic(string daoPath)
        {
            Assembly a = Assembly.UnsafeLoadFrom(daoPath);
            Type? classToCreate = null;

            foreach (Type type in a.GetTypes())
            {
                if (type.IsAssignableTo(typeof(IDAO)))
                {
                    classToCreate = type;
                    break;

                }
            }

            if (classToCreate != null)
            {
                dao = (IDAO)Activator.CreateInstance(classToCreate, null);
            }
        }


        public IEnumerable<ICompany> GetCompanies()
        {
            return dao.GetCompanies();
        }

        public IEnumerable<IPlane> GetPlanes()
        {
            return dao.GetPlanes();
        }

        public ICompany NewCompany()
        {
            return dao.NewCompany();
        }

        public void SaveCompany(ICompany company)
        {
            dao.SaveCompany(company);
        }

        public void DeleteCompany(ICompany company)
        {
            dao.DeleteCompany(company);
        }

        public IPlane NewPlane()
        {
            return dao.NewPlane();
        }

        public void SavePlane(IPlane plane)
        {
            dao.SavePlane(plane);
        }

        public void DeletePlane(IPlane plane)
        {
            dao.DeletePlane(plane);
        }

      
    }
}