using Tabulator_Crud.Models.Domain;

namespace Tabulator_Crud.Repository
{
    public interface IAttendanceRepository : IRepository<Attendance>
    {
        List<Attendance> GetReport(int empId, int comId);
        public List<AttendanceSummaryViewModel> GetAttendanceSummary(int compId, int thisYear);
        void AddAttendance(Attendance attendance);
        public List<Attendance> GetAttendances();

    }
}