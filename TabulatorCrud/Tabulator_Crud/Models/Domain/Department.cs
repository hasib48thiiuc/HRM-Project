using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Tabulator_Crud.Models.Domain
{
    public class Department
    {
        [Key]

        public int DeptId { get; set; } 

        public string DeptName { get; set; }

        //ForeignKeys
        [ForeignKey(nameof(Company))]
        public int CompanyId {  get; set; }

        [NotMapped]
        public Company Company { get; set; }

        // Navigation properties
        [JsonIgnore]
        public List<Employee> Employees { get; set; }
    }
}
