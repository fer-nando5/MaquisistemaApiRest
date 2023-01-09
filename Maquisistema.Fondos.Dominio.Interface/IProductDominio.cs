using Maquisistema.Fondos.Dominio.Entity;

namespace Maquisistema.Fondos.Dominio.Interface
{
    public interface IProductDominio
    {
        #region Metodos Sincronos
        bool Insert(Product product);
        bool Update(Product product);
        bool Delete(string Id);
        Product get(string Id);
        IEnumerable<Product> GetAll();
        #endregion

        #region Metodos Asyncronos
        Task<bool> InsertAsync(Product product);
        Task<bool> UpdateAsync(Product product);
        Task<bool> DeleteAsync(string Id);
        Task<Product> getAsync(string Id);
        Task<IEnumerable<Product>> GetAllAsync();
        #endregion
    }
}
