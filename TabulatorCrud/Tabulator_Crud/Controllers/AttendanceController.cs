using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NuGet.Protocol;
using Tabulator_Crud.Models.Domain;
using Tabulator_Crud.Repository;

namespace Tabulator_Crud.Controllers
{
    public class AttendanceController : Controller
    {
        private IAttendanceRepository _attendanceRepo;

        private IDepartmentRepository _departmentRepo;
        private IDesignationRepository _designationRepo;
        private IEmployeeRepository _employeeRepo;

        public AttendanceController(IAttendanceRepository attendanceRepo
            ,IDepartmentRepository departmentRepository,
            IDesignationRepository designationRepo,
            IEmployeeRepository employeeRepo)
        {
            _attendanceRepo = attendanceRepo;
            _departmentRepo = departmentRepository;

            _designationRepo = designationRepo;
            _employeeRepo = employeeRepo;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            string selectedCompanyJson = HttpContext.Request.Cookies["selectedCompany"];
            Company? selectedCompany = selectedCompanyJson.FromJson<Company>();

            ViewBag.Departments = _departmentRepo.GetAll().Where(x => x.CompanyId == selectedCompany.ComId).ToList();

            ViewBag.Designations = _designationRepo.GetAll().Where(x => x.CompanyId == selectedCompany.ComId).ToList();

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Attendance attendance)
        {
            try
            {
                string selectedCompanyJson = HttpContext.Request.Cookies["selectedCompany"];
                Company? selectedCompany = selectedCompanyJson.FromJson<Company>();
                attendance.ComId = selectedCompany.ComId;

                TimeSpan time = _employeeRepo.GetShiftbyId(attendance.EmpId);



                if (attendance.InTime > time)
                {
                    attendance.AttStatus = "Late";
                }
                else if (attendance.InTime == null && attendance.OutTime == null && attendance.DtDate != null)
                    attendance.AttStatus = "Absent";
                else if (attendance.DtDate.DayOfWeek.ToString() == "Friday" )
                {
                    attendance.AttStatus = "Weekend";
                }

                else 
                {
                    attendance.AttStatus = "Present";

                }

                _attendanceRepo.Add(attendance);

                return RedirectToAction("Show");
            }
            catch
            {
                return RedirectToAction("Show");
            }
        }

        [HttpGet]
        public IActionResult GetEmployees(int departmentId)

        {
            try
            {
                string selectedCompanyJson = HttpContext.Request.Cookies["selectedCompany"];
                Company? selectedCompany = selectedCompanyJson.FromJson<Company>();
                int compid = selectedCompany.ComId;

                var employees = _employeeRepo.GetEmployeeByDepartmentCompany(departmentId, compid);
                return Json(employees);
            }
            catch (Exception ex)
            {
                // Log the exception for debugging
                Console.WriteLine(ex.ToString());
                return StatusCode(500, "Internal Server Error");
            }
        }


        public IActionResult Show()
        {
            return View();
        }
        [HttpGet]
        public IActionResult GetAttendanceData()
        {

            List<Attendance> attendances = _attendanceRepo.GetAttendances();
             return Json(attendances);
        }

        public IActionResult ShowAttendanceData()
        {


            return View();
        }
        [HttpGet]
        public IActionResult ShowSummary()
        {
           //  Employee emp= _employeeRepo.GetById(id);
            string selectedCompanyJson = HttpContext.Request.Cookies["selectedCompany"];
            Company? selectedCompany = selectedCompanyJson.FromJson<Company>();
            int compid = selectedCompany.ComId;


            List<AttendanceSummaryViewModel> summary = _attendanceRepo.GetAttendanceSummary(compid, 2023);
           
            List<Employee> emps = _employeeRepo.GetAll().ToList();
           for(int i=0;i<summary.Count();i++)
            {

                summary[i].empName = emps.Where(x => x.EmpId == summary[i].EmpId).FirstOrDefault().EmpName;
            }


            return Json(summary);
        }

    }
}
