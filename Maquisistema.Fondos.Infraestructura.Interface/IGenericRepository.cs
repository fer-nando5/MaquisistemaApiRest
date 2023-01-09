namespace Maquisistema.Fondos.Infraestructura.Interface
{
    public interface IGenericRepository<T> where T : class
    {

        #region Metodos Sincronos
        bool Insert(T entity);
        bool Update(T entity);
        bool Delete(string Id);
        T get(string Id);
        IEnumerable<T> GetAll();
        #endregion

        #region Metodos Asyncronos
        Task<bool> InsertAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(string Id);
        Task<T> getAsync(string Id);
        Task<IEnumerable<T>> GetAllAsync();
        #endregion
    }
}
