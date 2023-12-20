using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using Tabulator_Crud.Models.Domain;
using Tabulator_Crud.Repository;

namespace Tabulator_Crud.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: DepartmentController

        private IDepartmentRepository _departmentRepo;

        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _departmentRepo = departmentRepository;
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
        public ActionResult Create(Department department)
        {
            try
            {
                string selectedCompanyJson = HttpContext.Request.Cookies["selectedCompany"];
                Company? selectedCompany = selectedCompanyJson.FromJson<Company>();
                department.CompanyId = selectedCompany.ComId;
               
                _departmentRepo.Add(department);
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

            List<Department> depts=_departmentRepo.GetAll().Where(x=>x.CompanyId==selectedCompany.ComId).ToList();

            return Json(depts);
        }
        public IActionResult Edit(int id)
        {
            var department = _departmentRepo.GetById(id);

            return View(department);
        }
        [HttpPost]
        public IActionResult Edit(Department department)
        {
            string selectedCompanyJson = HttpContext.Request.Cookies["selectedCompany"];
            
            Company? selectedCompany = selectedCompanyJson.FromJson<Company>();

            department.CompanyId= selectedCompany.ComId;
                _departmentRepo.Update(department);


            return RedirectToAction("Create");
        }
        public IActionResult Delete(int id)
        {
             _departmentRepo.Delete(id);


            return RedirectToAction("Create");
        }

    }
}
