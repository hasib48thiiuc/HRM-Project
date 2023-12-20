using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using Tabulator_Crud.Models.Domain;
using Tabulator_Crud.Repository;

namespace Tabulator_Crud.Controllers
{
    public class ShiftController : Controller
    {
        private IShiftRepository _shiftRepo;

        public ShiftController(IShiftRepository shiftRepo)
        {
            _shiftRepo = shiftRepo;
          
        }
        public ActionResult Index()
        {
            return View();
        }

        // GET: DepartmentController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DepartmentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DepartmentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Shift shift)
        {
            try
            {
                string selectedCompanyJson = HttpContext.Request.Cookies["selectedCompany"];
                Company? selectedCompany = selectedCompanyJson.FromJson<Company>();
                shift.CompanyId = selectedCompany.ComId;

                _shiftRepo.Add(shift);
                return Json(shift);
            }
            catch
            {
                return View();
            }
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            string selectedCompanyJson = HttpContext.Request.Cookies["selectedCompany"];
            Company? selectedCompany = selectedCompanyJson.FromJson<Company>();

            List<Shift> shifts = _shiftRepo.GetAll().Where(x => x.CompanyId == selectedCompany.ComId).ToList();

            return Json(shifts);
        }
        public IActionResult Edit(int id)
        {
            var shift = _shiftRepo.GetById(id);

            return View(shift);
        }
        [HttpPost]
        public IActionResult Edit(Shift shift)
        {
            string selectedCompanyJson = HttpContext.Request.Cookies["selectedCompany"];

            Company? selectedCompany = selectedCompanyJson.FromJson<Company>();

            shift.CompanyId = selectedCompany.ComId;
            _shiftRepo.Update(shift);


            return RedirectToAction("Create");
        }
        public IActionResult Delete(int id)
        {
            _shiftRepo.Delete(id);


            return RedirectToAction("Create");
        }

    }
}
