using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using nr148081_150251.Samoloty.BL;
using nr148081_150251.Samoloty.Web.Helpers;
using nr148081_150251.Samoloty.Web.Models.Company;
using nr148081_150251.Samoloty.Web.Models.Plane;

namespace nr148081_150251.Samoloty.Web.Controllers
{
    public class CompanyController : Controller
    {
        private readonly Logic _logic;
        private readonly IMapper _mapper;
        public CompanyController(Logic logic, IMapper mapper) 
        {
            _logic = logic;
            _mapper = mapper;
        }

        public IActionResult Index(string? valueFilter, string? fieldSort, SortDirection? directionSort)
        {
            string? errorMessage = TempData["ErrorMessage"] as string;
            ViewBag.ErrorMessage = errorMessage;

            var companies = _logic.GetCompanies();
            IEnumerable<CompanyViewModel> companiesViewModel = new List<CompanyViewModel>();
            _mapper.Map(companies, companiesViewModel);


            if (valueFilter != null)
            {
                companiesViewModel = companiesViewModel.Where(x => x.Name.Contains(valueFilter));
            }




            ViewBag.SortFields = ViewModelsHelper.GetSelectListItems<CompanyViewModel>();
            ViewBag.ValueFilter = valueFilter;

            companiesViewModel = companiesViewModel.Sort(fieldSort, directionSort);         
            return View(companiesViewModel);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CompanyViewModel companyViewModel)
        {
            if (!ModelState.IsValid)
            {         
                return View();
            }

            var company = _logic.NewCompany();
            _mapper.Map(companyViewModel, company);


            _logic.SaveCompany(company);

            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var company = _logic.GetCompany(id);
            if (company == null)
            {
                return NotFound();
            }

            var companyViewModel = _mapper.Map<CompanyViewModel>(company);

            return View(companyViewModel);
        }

        [HttpPost]
        public IActionResult Edit(CompanyViewModel companyViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(companyViewModel);
            }

            var company = _logic.GetCompany(companyViewModel.Id);
            if (company == null)
            {
                return NotFound();
            }

            _mapper.Map(companyViewModel, company);
       
            return RedirectToAction("Index");
        }


        [HttpPost, ActionName("Delete")]
        public IActionResult Delete(int id)
        {
            var company = _logic.GetCompany(id);
            if (company == null)
            {
                return RedirectToAction("Index");         
            }
            try
            {
                _logic.DeleteCompany(company);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

    }
}
