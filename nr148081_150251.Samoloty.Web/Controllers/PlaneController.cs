using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using nr148081_150251.Samoloty.BL;
using nr148081_150251.Samoloty.Web.Models.Plane;

namespace nr148081_150251.Samoloty.Web.Controllers
{
    public class PlaneController : Controller
    {
        private readonly Logic _logic;
        private readonly IMapper _mapper;

        public PlaneController(Logic logic, IMapper mapper)
        {
            _logic = logic;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var planes = _logic.GetPlanes();
            IEnumerable<PlaneViewModel> planesViewModel = new List<PlaneViewModel>();
            _mapper.Map(planes, planesViewModel);
            return View(planesViewModel);
        }

        [HttpGet]
        public IActionResult Add(int id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(PlaneViewModel planeViewModel)
        {
            return View();
        }


        [HttpGet]
        public IActionResult Edit(int id) 
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Edit(PlaneViewModel planeViewModel) 
        {

            return View();
        }
    }
}
