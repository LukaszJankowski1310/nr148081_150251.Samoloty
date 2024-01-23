using Microsoft.AspNetCore.Mvc;
using nr148081_150251.Samoloty.BL;

namespace nr148081_150251.Samoloty.Web.Controllers
{
    public class CompanyController : Controller
    {
        private readonly Logic _logic;
        public CompanyController(Logic logic) 
        {
            _logic = logic;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
