using Tabulator_Crud.Models;
using Tabulator_Crud.Models.Domain;

namespace Tabulator_Crud.Repository
{
    public class AttSummaryRepo : Repository<Attendance>, IAttSummaryRepo
    {
        public AttSummaryRepo(TabulatorDbContext ctx) : base(ctx)
        {
        }
    }
}
