namespace Maquisistema.Fondos.Infraestructura.Interface
{
    public interface IUnitOfWork
    {
        IProductRepository Product { get; }
    }
}
