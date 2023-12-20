using Microsoft.EntityFrameworkCore;
using Tabulator_Crud.Models;

namespace Tabulator_Crud.Repository
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {

        public StudentRepository(TabulatorDbContext ctx) : base(ctx)
        {

        }

        
    }
}
