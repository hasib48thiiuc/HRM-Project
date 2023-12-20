using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Tabulator_Crud.Models.Domain
{
    public class Attendance
    {

        [Key, Column(Order = 1)]
        public int ComId { get; set; }

        [Key, Column(Order = 2)]
        public int EmpId { get; set; }

        [Key, Column(Order = 3)]
        public DateTime DtDate { get; set; }

        // Other properties
        public string AttStatus { get; set; }
        public TimeSpan? InTime { get; set; }
        public TimeSpan? OutTime { get; set; }

        // Navigation properties
        public Company Company { get; set; }
        public Employee Employee { get; set; }


    }
}
