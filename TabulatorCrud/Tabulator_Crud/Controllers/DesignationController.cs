using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using Tabulator_Crud.Models.Domain;
using Tabulator_Crud.Repository;

namespace Tabulator_Crud.Controllers
{
    public class DesignationController : Controller
    {
        private IDesignationRepository _designationRepo;

        public DesignationController(IDesignationRepository designationRepository)
        {
            _designationRepo = designationRepository;
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
        public ActionResult Create(Designation department)
        {
            try
            {
                string selectedCompanyJson = HttpContext.Request.Cookies["selectedCompany"];
                Company? selectedCompany = selectedCompanyJson.FromJson<Company>();
                department.CompanyId = selectedCompany.ComId;

                _designationRepo.Add(department);
                return Json(department);
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

            List<Designation> depts = _designationRepo.GetAll().Where(x => x.CompanyId == selectedCompany.ComId).ToList();

            return Json(depts);
        }
        public IActionResult Edit(int id)
        {
            var department = _designationRepo.GetById(id);

            return View(department);
        }
        [HttpPost]
        public IActionResult Edit(Designation department)
        {
            string selectedCompanyJson = HttpContext.Request.Cookies["selectedCompany"];

            Company? selectedCompany = selectedCompanyJson.FromJson<Company>();

            department.CompanyId = selectedCompany.ComId;
            _designationRepo.Update(department);


            return RedirectToAction("Create");
        }
        public IActionResult Delete(int id)
        {
            _designationRepo.Delete(id);


            return RedirectToAction("Create");
        }

    }
}
