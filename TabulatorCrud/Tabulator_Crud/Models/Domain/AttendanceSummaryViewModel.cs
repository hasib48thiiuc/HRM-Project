using System.Text.RegularExpressions;

namespace Tabulator_Crud.Models.Domain
{
    public class AttendanceSummaryViewModel
    {
        public int EmpId { get; set; }

        public string empName { get; set; }
        public int Month { get; set; }
        public int PresentCount { get; set; }
        public int AbsentCount { get; set; }
        public int LateCount { get; set; }

   
     
    }
}
