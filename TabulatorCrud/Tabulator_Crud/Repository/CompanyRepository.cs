using Tabulator_Crud.Models;
using Tabulator_Crud.Models.Domain;

namespace Tabulator_Crud.Repository
{
    public class CompanyRepository:Repository<Company>,ICompanyRepository
    {
        public CompanyRepository(TabulatorDbContext ctx) : base(ctx)
        {

        }
    }
}
