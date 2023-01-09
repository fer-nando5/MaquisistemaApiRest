using Dapper;
using Maquisistema.Fondos.Dominio.Entity;
using Maquisistema.Fondos.Infraestructura.Data;
using Maquisistema.Fondos.Infraestructura.Interface;
using System.Data;

namespace Maquisistema.Fondos.Infraestructura.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly DapperContext _context;
        public ProductRepository(DapperContext context)
        {
            this._context = context;
        }
            
        #region Metodos Sincronos
        public bool Insert(Product product)
        {
            using (var connection=_context.createConnection())
            {
                var query = "ProductInsert";
                var parameters = new DynamicParameters();
                parameters.Add("Name", product.Name);
                parameters.Add("Status", product.Status);
                parameters.Add("Stock", product.Stock);
                parameters.Add("Description", product.Description);
                parameters.Add("Price", product.Price);

                var result = connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public bool Update(Product product)
        {
            using (var connection = _context.createConnection())
            {
                var query = "ProducUpdate";
                var parameters = new DynamicParameters();
                parameters.Add("ProductId", product.ProductId);
                parameters.Add("Name", product.Name);
                parameters.Add("Status", product.Status);
                parameters.Add("Stock", product.Stock);
                parameters.Add("Description", product.Description);
                parameters.Add("Price", product.Price);

                var result = connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }
        public bool Delete(string Id)
        {
            using (var connection = _context.createConnection())
            {
                var query = "ProducDelete";
                var parameters = new DynamicParameters();
                parameters.Add("ProductId", Id);

                var result = connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public Product get(string Id)
        {
            using (var connection = _context.createConnection())
            {
                var query = "ProducGetByID";
                var parameters = new DynamicParameters();
                parameters.Add("ProductId", Id);

                var product = connection.QuerySingle<Product>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return product;
            }
        }

        public IEnumerable<Product> GetAll()
        {
            using(var connection = _context.createConnection())
            {
                var query = "ProducList";
                var product = connection.Query<Product>(query, commandType: CommandType.StoredProcedure);
                return product;
            }
        }
        #endregion


        #region Metodos Asincronos
        public async Task<bool> InsertAsync(Product product)
        {
            using( var connection = _context.createConnection())
            {
                var query = "ProductInsert";
                var parameters = new DynamicParameters();
                parameters.Add("Name", product.Name);
                parameters.Add("Status", product.Status);
                parameters.Add("Stock", product.Stock);
                parameters.Add("Description", product.Description);
                parameters.Add("Price", product.Price);

                var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0; 
            }
        }

        public async Task<bool> UpdateAsync(Product product)
        {
            using(var connectio = _context.createConnection())
            {
                var query = "ProducUpdate";
                var parameters = new DynamicParameters();
                parameters.Add("ProductId", product.ProductId);
                parameters.Add("Name", product.Name);
                parameters.Add("Status", product.Status);
                parameters.Add("Stock", product.Stock);
                parameters.Add("Description", product.Description);
                parameters.Add("Price", product.Price);

                var result = await connectio.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public async Task<bool> DeleteAsync(string Id)
        {
            using (var connection = _context.createConnection())
            {
                var query = "ProducDelete";
                var parameters = new DynamicParameters();
                parameters.Add("ProductId", Id);

                var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public async Task<Product> getAsync(string Id)
        {
            using (var connection = _context.createConnection())
            {
                var query = "ProducGetByID";
                var parameters = new DynamicParameters();
                parameters.Add("ProductId", Id);

                var product = await connection.QuerySingleAsync<Product>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return product;
            }
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            using (var connection = _context.createConnection())
            {
                var query = "ProducList";
                var product = await connection.QueryAsync<Product>(query, commandType: CommandType.StoredProcedure);
                return product;
            }
        }
        #endregion
    }
}
