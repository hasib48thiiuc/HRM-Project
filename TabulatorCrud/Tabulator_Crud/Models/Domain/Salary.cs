
     using System.Text.RegularExpressions;

namespace Tabulator_Crud.Models.Domain
    {
        public class Salary
        {
            public int EmpId { get; set; }

            public string empName { get; set; }
            public int Month { get; set; }
            public int PresentCount { get; set; }
            public int AbsentCount { get; set; }
            public int LateCount { get; set; }

            public int Gross { get; set; }

            public int Basic { get; set; }
            public int Hrent { get; set; }

            public int Medical { get; set; }
             
            public int others { get; set; } 
            public int AbsentAmount { get; set; }
            public int PayableAmount { get; set; }

            public bool IsPaid { get; set; }

        public int PaidAmount { get; set; }


        }
    }

