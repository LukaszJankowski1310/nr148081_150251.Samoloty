using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using nr148081_150251.Samoloty.BL;
using nr148081_150251.Samoloty.Core;
using nr148081_150251.Samoloty.Interfaces;
using nr148081_150251.Samoloty.Web.Helpers;
using nr148081_150251.Samoloty.Web.Models;
using nr148081_150251.Samoloty.Web.Models.Company;
using nr148081_150251.Samoloty.Web.Models.Plane;
using System.Diagnostics;

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

        public IActionResult Index(string? valueFilter, string? fieldSort, SortDirection? directionSort)
        {
            var planes = _logic.GetPlanes();    
            IEnumerable<PlaneViewModel> planesViewModel = new List<PlaneViewModel>();
            _mapper.Map(planes, planesViewModel);


            if (valueFilter != null)
            {
                planesViewModel = planesViewModel.Where(x => x.Model.Contains(valueFilter));
            }

            planesViewModel = planesViewModel.Sort(fieldSort, directionSort);

            ViewBag.SortFields = ViewModelsHelper.GetSelectListItems<PlaneViewModel>();
            ViewBag.ValueFilter = valueFilter;

            return View(planesViewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            FillViewBag();

            return View();
        }

        [HttpPost]
        public IActionResult Create(PlaneEditViewModel planeViewModel)
        {
            if (!ModelState.IsValid)
            {
                FillViewBag();
                return View(planeViewModel);
            }

            var plane = _logic.NewPlane();
            Map(plane, planeViewModel);

            _logic.SavePlane(plane);

            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Edit(int id) 
        {
            var plane = _logic.GetPlane(id);
            if (plane == null)
            {
                return NotFound();
            }
                   
            var planeViewModel = _mapper.Map<PlaneEditViewModel>(plane);
            FillViewBag();
            return View(planeViewModel);
        }
        
        [HttpPost]
        public IActionResult Edit(PlaneEditViewModel planeViewModel) 
        {
            if (!ModelState.IsValid)
            {
                FillViewBag();
                return View(planeViewModel);
            }

            var plane = _logic.GetPlane(planeViewModel.Id);
            if (plane == null)
            {
                return NotFound();
            }
            Map(plane, planeViewModel);
            return RedirectToAction("Index");
        }


        [HttpPost, ActionName("Delete")]
        public IActionResult Delete(int id)
        {
            var plane = _logic.GetPlane(id);
            if (plane != null)
            {
             _logic.DeletePlane(plane);
            }

           return RedirectToAction("Index");
        }



        private void FillViewBag()
        {
            var comapnies = _logic.GetCompanies();

            ViewBag.Types = Enum.GetValues(typeof(PlaneTypeViewModel)).Cast<PlaneTypeViewModel>()
                .Select(e => new SelectListItem { Value = e.ToString(), Text = e.GetDisplayName() })
                     .ToList();
            ViewBag.Companies = new SelectList(comapnies, "Id", "Name");
        }


        private void Map(IPlane plane, PlaneEditViewModel planeViewModel)
        {
            plane.Model = planeViewModel.Model;
            plane.Type = _mapper.Map<PlaneType>(planeViewModel.Type);
            plane.MaximumSpeed = planeViewModel.MaximumSpeed;
            plane.Company = _logic.GetCompany(planeViewModel.Company.Id);
        }

    }
}
