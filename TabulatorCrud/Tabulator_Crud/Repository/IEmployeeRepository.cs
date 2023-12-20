using Tabulator_Crud.Models.Domain;

namespace Tabulator_Crud.Repository
{
    public interface IEmployeeRepository:IRepository<Employee>

    { 
     List<Employee> GetAllEmployee();
        List<Employee> GetEmployeeByDepartmentCompany(int departmentId,int compid);
        List<AttendanceSummary> GetReport(int empId, int comId);
        TimeSpan GetShiftbyId(int empId);
    }


}