using System.ComponentModel.DataAnnotations;

namespace Tabulator_Crud.Models.Domain
{
    public class Company
    {
        [Key]
        public int ComId { get; set; }

        public string ComName { get; set;}

        public int Basic { get; set;}

        public int HRent { get; set; }

        public int medical { get; set; }

        public bool IsInactive { get; set; }

        public List<Department> Departments { get; set; }

        public List<Designation> DesignationList { get; set;}

        public List<Employee> Employees { get; set; }


    }
}
