using Microsoft.EntityFrameworkCore;
using System.ComponentModel.Design;
using Tabulator_Crud.Models;
using Tabulator_Crud.Models.Domain;

namespace Tabulator_Crud.Repository
{
    public class EmployeeRepository : Repository<Employee>,IEmployeeRepository
    {
        public EmployeeRepository(TabulatorDbContext ctx) : base(ctx)
        {
        }
        public List<Employee> GetAllEmployee()
        {
            List<Employee> employees = _ctx.Employees
              .Include(e => e.Department)
              .Include(e => e.Designation)
              .Include(e => e.Shift)
              // Add more includes for other related entities as needed
              .ToList();
            return employees;
        }

        public List<AttendanceSummary> GetReport(int empId, int comId)
        {
            
            List<AttendanceSummary> summary=new List<AttendanceSummary> ();

            return summary;
           
        }

        public TimeSpan GetShiftbyId(int empId)
        {
            Employee emp = _ctx.Employees.Where(x=>x.EmpId == empId).Include(y=>y.Shift).FirstOrDefault();

            TimeSpan temp = emp.Shift.shiftLate;
            return temp;
        }

        List<Employee> IEmployeeRepository.GetEmployeeByDepartmentCompany(int departmentId, int compid)
        {
            
            var employees = _ctx.Employees
            .Where(e => e.ComId == compid && e.DeptId == departmentId)
            .Include(x=>x.Shift)
            .ToList();

            return employees;
        }
    }
}
