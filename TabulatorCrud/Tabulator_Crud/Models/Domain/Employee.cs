using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Reflection.Emit;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace Tabulator_Crud.Models.Domain
{
    public class Employee
    {
        [Key]

        public int EmpId { get; set; }
        public string EmpCode { get; set; }
        public string EmpName { get; set; }

        // Foreign keys referencing Company, Shift, Department, and Designation

        [ForeignKey(nameof(Company))]
        public int ComId { get; set; }

        [ForeignKey(nameof(Shift))]
        public int ShiftId { get; set; }
        [ForeignKey(nameof(Department))]
        public int DeptId { get; set; }
        [ForeignKey(nameof(Designation))]
        public int DesigId { get; set; }

        public string Gender { get; set; }

        [Range(10001, int.MaxValue, ErrorMessage ="The Value must be greater than 10000")]
        public decimal Gross { get; set; }
        public decimal Basic { get; set; }
        public decimal HRent { get; set; }
        public decimal Medical { get; set; }
        public decimal Others { get; set; }
        public DateTime DtJoin { get; set; }

        // Navigation properties
        public Company Company { get; set; }
        public Shift Shift { get; set; }
        public Department Department { get; set; }
        public Designation Designation { get; set; }

        // Attendance navigation properties
        [JsonIgnore]
        public List<Attendance> Attendances { get; set; }

    }
}
