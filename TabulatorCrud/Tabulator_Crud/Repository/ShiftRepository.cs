using Tabulator_Crud.Models;
using Tabulator_Crud.Models.Domain;

namespace Tabulator_Crud.Repository
{
    public class ShiftRepository : Repository<Shift>, IShiftRepository
    {
        public ShiftRepository(TabulatorDbContext ctx) : base(ctx)
        {
        }


    }
}
