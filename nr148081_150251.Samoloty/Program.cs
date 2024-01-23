using nr148081_150251.Samoloty.BL;
using System.Net.Http.Headers;



namespace nr148081_150251.Samoloty
{
    class Program
    {
        static void Main(string[] args)
        {
            string libraryName = System.Configuration.ConfigurationManager.AppSettings["DBLibraryName"];
            if (libraryName == null)
            {
                throw new ArgumentNullException(nameof(libraryName));
            }
            var blc = new Logic(libraryName);

            var companies = blc.GetCompanies();
            var planes = blc.GetPlanes();

            



            //BLC.BLC blc = new CarsApp.BLC.BLC(libraryName);

            //foreach (IProducer p in blc.GetProducers())
            //{
            //    Console.WriteLine($"{p.ID}: {p.Name}");
            //}

            //Console.WriteLine("-----------------------------");

            //foreach (ICar c in blc.GetCars())
            //{
            //    Console.WriteLine($"{c.ID}: {c.Producer.Name} {c.Name} {c.ProductionYear}");
            //}




        }
    }
}

