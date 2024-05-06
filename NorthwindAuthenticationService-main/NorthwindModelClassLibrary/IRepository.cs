namespace NorthwindModelClassLibrary
{
    public interface IRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll(); 
        TEntity GetById(int id);
        void CreateNew(TEntity entity);
        void Update(TEntity entity);
        void Remove(int id);
    }
    public interface IRepositoryAsync<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetById(int id);
        Task CreateNew(TEntity entity);
        Task Update(TEntity entity);
        Task Remove(int id);
    }
}
