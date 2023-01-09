using Maquisistema.Fondos.Infraestructura.Interface;

namespace Maquisistema.Fondos.Infraestructura.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public IProductRepository Product { get; }

        public UnitOfWork(IProductRepository product)
        {
            Product = product;
        }
        public void Dispose()
        {
            System.GC.SuppressFinalize(this);
        }
    }
}
