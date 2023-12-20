using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;
using Tabulator_Crud.Models.Domain;
using Tabulator_Crud.Repository;

namespace Tabulator_Crud.Controllers
{
    public class EmployeeController : Controller
    {
        private IEmployeeRepository _employeeRepo;
        private IDepartmentRepository _departmentRepo;
        private IDesignationRepository _designationRepo;
        private IShiftRepository _shiftRepo;
        public EmployeeController(IEmployeeRepository employeeRepository,
            IDepartmentRepository departmentRepository,
            IDesignationRepository designationRepository,
            IShiftRepository shiftRepository
             )
        {
            _employeeRepo= employeeRepository;
            _departmentRepo= departmentRepository;
            _designationRepo= designationRepository;
            _shiftRepo= shiftRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            string selectedCompanyJson = HttpContext.Request.Cookies["selectedCompany"];

            Company company = selectedCompanyJson.FromJson<Company>();

            
            ViewBag.Departments =_departmentRepo.GetAll().Where(x=>x.CompanyId==company.ComId).ToList();

            ViewBag.Designations= _designationRepo.GetAll().Where(x=>x.CompanyId==company.ComId).ToList();
            ViewBag.shifts = _shiftRepo.GetAll().Where(x => x.CompanyId == company.ComId).ToList();

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee emp)
        {
            if(ModelState.IsValid)
            {
                string selectedCompanyJson = HttpContext.Request.Cookies["selectedCompany"];
                Company? selectedCompany = selectedCompanyJson.FromJson<Company>();
                emp.ComId = selectedCompany.ComId;

                _employeeRepo.Add(emp);
                return RedirectToAction("Show");
            }

           else
            {
                // ModelState is not valid, so return to the form with validation errors
                // Inspect ModelState errors here
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                foreach (var error in errors)
                {
                    Console.WriteLine($"Model error: {error.ErrorMessage}");
                }

                return RedirectToAction("Create");
            }
        }
        public IActionResult CalculateAllowances(decimal gross)
{
            
            string selectedCompanyJson = HttpContext.Request.Cookies["selectedCompany"];
           Company? selectedCompany = selectedCompanyJson.FromJson<Company>();
            var basic = gross * ((decimal)selectedCompany.Basic / 100);
            var medical = gross * ((decimal)selectedCompany.medical / 100);
            var hrent = gross * ((decimal)selectedCompany.HRent / 100);

          

                var allowances = new { basic, medical, hrent };

               return Json(allowances);
             }

        public IActionResult Show()
        {
            return View();
        }
        [HttpGet]
        public IActionResult GetAllEmployee()
        {
            List<Employee> employees = _employeeRepo.GetAllEmployee();

            return Json(employees);
        }
        public IActionResult Edit(int id)
        {
            Employee employee = _employeeRepo.GetById(id);
            ViewBag.Departments = _departmentRepo.GetAll().ToList();
            ViewBag.Designations = _designationRepo.GetAll().ToList();
            ViewBag.shifts = _shiftRepo.GetAll().ToList();
            return View(employee);
        }
        [HttpPost]
        public IActionResult Edit(Employee emp)
        {
            string selectedCompanyJson = HttpContext.Request.Cookies["selectedCompany"];
            Company? selectedCompany = selectedCompanyJson.FromJson<Company>();
            emp.ComId = selectedCompany.ComId;
            _employeeRepo.Update(emp);
            return RedirectToAction("Show");

        }
        public IActionResult Delete(int id)
        {
            _employeeRepo.Delete(id);
            return RedirectToAction("Show");

        }
    }
}
