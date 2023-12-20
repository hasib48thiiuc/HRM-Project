using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Tabulator_Crud.Models.Domain
{
    public class Shift
    {
       public int Id { get; set; }

        public string shiftName {  get; set; }

        public TimeSpan shiftIn { get; set;}

        public TimeSpan shiftOut { get; set;}

        public TimeSpan shiftLate { get; set; }
        [ForeignKey(nameof(Company))]
        public int CompanyId {  get; set; } 

        public Company Company { get; set; }

        [JsonIgnore]
        public List<Employee> Employees { get; set; }

    }
}
