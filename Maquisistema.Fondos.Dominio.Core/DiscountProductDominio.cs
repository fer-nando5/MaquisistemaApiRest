using Maquisistema.Fondos.Infraestructura.Interface;
using Maquisistema.Fondos.Dominio.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maquisistema.Fondos.Dominio.Core
{
    public class DiscountProductDominio : IDiscountProductDominio
    {

        private readonly IDiscountProductRepository _discountProductRepository;
        public DiscountProductDominio(IDiscountProductRepository discountProductRepository)
        {
            _discountProductRepository = discountProductRepository;
        }

        public async Task<int> GetDiscount(int id)
        {
            return await _discountProductRepository.GetDiscount(id);
        }
    }
}
