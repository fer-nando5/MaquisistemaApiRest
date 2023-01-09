using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maquisistema.Fondos.Dominio.Interface
{
    public interface IDiscountProductDominio
    {
        Task<int> GetDiscount(int id);
    }
}
