using System.ComponentModel.DataAnnotations;

namespace Tabulator_Crud.Models
{
    public class Student
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string  Email { get; set; }
    }
}
