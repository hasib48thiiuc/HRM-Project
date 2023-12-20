using Microsoft.EntityFrameworkCore;
using Tabulator_Crud.Models;

namespace Tabulator_Crud.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected TabulatorDbContext _ctx;


        protected DbSet<TEntity> _dbset;


        public Repository(TabulatorDbContext ctx)
        {
            _ctx = ctx;
            _ctx.Database.SetCommandTimeout(20);
            _dbset = _ctx.Set<TEntity>();

        }

        public void Add(TEntity item)
        {
            

            _dbset.Add(item);
            _ctx.SaveChanges();
        }

        public IEnumerable<TEntity> GetAll()
        {

           
            IEnumerable<TEntity> items = _dbset.ToList();


            return items;


        }
        public TEntity GetById(int id)
        {
            var item = _dbset.Find(id);
            return item;

        }

        public void Update(TEntity item)
        {
            _dbset.Update(item);
            _ctx.SaveChanges();
        }

        public void Delete(int id)
        {
            if (_dbset.Find(id) != null)
            {
                _dbset.Remove(_dbset.Find(id));
                _ctx.SaveChanges();

            }
        }
    }
}
