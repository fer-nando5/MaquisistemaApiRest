using Maquisistema.Fondos.Dominio.Entity;
using Maquisistema.Fondos.Dominio.Interface;
using Maquisistema.Fondos.Infraestructura.Interface;

namespace Maquisistema.Fondos.Dominio.Core
{
    public class ProductDominio : IProductDominio
    {

        private readonly IUnitOfWork _unitOfWork;
        public ProductDominio(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }


        #region Metodos Sincronos
        public bool Insert(Product product)
        {
            return _unitOfWork.Product.Insert(product);
        }

        public bool Update(Product product)
        {
            return _unitOfWork.Product.Update(product);
        }

        public bool Delete(string Id)
        {
            return _unitOfWork.Product.Delete(Id);
        }

        public Product get(string Id)
        {
            return _unitOfWork.Product.get(Id);
        }

        public IEnumerable<Product> GetAll()
        {
            return _unitOfWork.Product.GetAll();    
        }
        #endregion



        #region Metodos Asyncronos
        public async Task<bool> InsertAsync(Product product)
        {
            return await _unitOfWork.Product.InsertAsync(product);
        }

        public async Task<bool> UpdateAsync(Product product)
        {
            return await _unitOfWork.Product.UpdateAsync(product);
        }

        public async Task<bool> DeleteAsync(string Id)
        {
            return await _unitOfWork.Product.DeleteAsync(Id);
        }

        public async Task<Product> getAsync(string Id)
        {
            return await _unitOfWork.Product.getAsync(Id);
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _unitOfWork.Product.GetAllAsync();
        }
        #endregion 
    }
}
