using Maquisistema.Fondos.Application.DTO;
using Maquisistema.Fondos.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maquisistema.Fondos.Application.Interface
{
    public interface IProductApplication
    {
        #region Metodos Sincronos
        Response<bool> Insert(ProductDto productDto);
        Response<bool> Update(ProductDto productDto);
        Response<bool> Delete(string Id);
        Response<ProductDto> get(string Id);
        Response<IEnumerable<ProductDto>> GetAll();
        #endregion

        #region Metodos Asyncronos
        Task<Response<bool>> InsertAsync(ProductDto productDto);
        Task<Response<bool>> UpdateAsync(ProductDto productDto);
        Task<Response<bool>> DeleteAsync(string Id);
        Task<Response<ProductDto>> getAsync(string Id);
        Task<Response<IEnumerable<ProductDto>>> GetAllAsync();
        #endregion
    }
}
