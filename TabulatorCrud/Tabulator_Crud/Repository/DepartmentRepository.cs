using NuGet.Protocol;
using Tabulator_Crud.Models;
using Tabulator_Crud.Models.Domain;

namespace Tabulator_Crud.Repository
{
    public class DepartmentRepository : Repository<Department>,IDepartmentRepository
    {
        public DepartmentRepository(TabulatorDbContext ctx) : base(ctx)
        {
        }

      
    }
}
