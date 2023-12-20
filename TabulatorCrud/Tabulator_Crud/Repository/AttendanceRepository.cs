using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using Tabulator_Crud.Models;
using Tabulator_Crud.Models.Domain;
using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace Tabulator_Crud.Repository
{
    public class AttendanceRepository : Repository<Attendance>, IAttendanceRepository
    {
        public AttendanceRepository(TabulatorDbContext ctx) : base(ctx)
        {
        }

        public List<Attendance> GetReport(int empId, int comId)
        {
            var result = _ctx.Attendances
                 .FromSqlRaw("EXEC GetAttendanceReport @empid, @compid, @this_year, @this_month",
                     new SqlParameter("@empid", empId),
                     new SqlParameter("@compid", comId),
                     new SqlParameter("@this_year", 2023 ),
                     new SqlParameter("@this_month", 12))
                 .ToList();

            return result;
        }
        public List<AttendanceSummaryViewModel> GetAttendanceSummary(int compId, int thisYear)
        {
            string connstring = "data source=DESKTOP-B476912\\SQLEXPRESS;initial catalog=Tabulator_CRUD;integrated security=true;TrustServerCertificate=True";
            List<AttendanceSummaryViewModel> attendanceSummaries = new List<AttendanceSummaryViewModel>();

            using (SqlConnection connection = new SqlConnection(connstring))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("GetAttendanceSummary4", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@compid", SqlDbType.Int) { Value = compId });
                    command.Parameters.Add(new SqlParameter("@this_year", SqlDbType.Int) { Value = thisYear });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            AttendanceSummaryViewModel summary = new AttendanceSummaryViewModel
                            {
                                EmpId = (int)reader["EmpId"],
                                Month = (int)reader["Month"],
                                PresentCount = (int)reader["PresentCount"],
                                AbsentCount = (int)reader["AbsentCount"],
                                LateCount = (int)reader["LateCount"]
                            };

                            attendanceSummaries.Add(summary);
                        }
                    }
                }
            }

            return attendanceSummaries;
        }

        public void AddAttendance(Attendance attendance)
        {

            _ctx.Attendances.Add(attendance);
            _ctx.SaveChanges(); 



        }
        public List<Attendance> GetAttendances()
        {

            List<Attendance> attendances= _ctx.Attendances.Include(x=>x.Employee).ToList(); 
            return attendances;
        }
    }

    
}
