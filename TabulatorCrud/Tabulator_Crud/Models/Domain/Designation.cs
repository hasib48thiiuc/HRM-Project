using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Tabulator_Crud.Models.Domain
{
    public class Designation
    {
        [Key]


        public int DesigId { get; set; }

        public string DesigName { get; set; }

        //ForeignKeys
        [ForeignKey(nameof(Company))]
        public int CompanyId { get; set; }

        
        public Company Company { get; set; }
        [JsonIgnore]
        public List<Employee> Employees { get; set; }

    }
}
