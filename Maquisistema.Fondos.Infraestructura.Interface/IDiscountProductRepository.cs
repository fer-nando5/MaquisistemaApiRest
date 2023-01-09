using Maquisistema.Fondos.Dominio.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maquisistema.Fondos.Infraestructura.Interface
{
    public interface IDiscountProductRepository
    {
        Task<int> GetDiscount(int id);
    }
}
