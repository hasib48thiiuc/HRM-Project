using Tabulator_Crud.Models;
using Tabulator_Crud.Models.Domain;

namespace Tabulator_Crud.Repository
{
    public class DesignationRepository : Repository<Designation>,IDesignationRepository
    {
        public DesignationRepository(TabulatorDbContext ctx) : base(ctx)
        {
        }
    }
}
