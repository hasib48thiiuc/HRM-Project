namespace Tabulator_Crud.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity item);
        void Delete(int id);
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);
        void Update(TEntity item);


    }
}