using Dapper.WebApi.Models;
using System.Collections.Generic;
using System.Linq;
using Dapper.WebApi.Services.Queries;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Dapper.WebApi.Services
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        private readonly ICommandText _commandText;

        public ProductRepository(IConfiguration configuration, ICommandText commandText) : base(configuration)
        {
            _commandText = commandText;

        }
        /*
        public async Task<IEnumerable<Product>> GetAllProducts()
        {

            return await WithConnection(async conn =>
            {
                var query = await conn.QueryAsync<Product>(_commandText.GetProducts);
                return query;
            });

        }
        */
        public async Task GetById(Product entity)
        {
            await WithConnection(async conn =>
            {
                var query = await conn.QueryFirstOrDefaultAsync<Product>(_commandText.GetProductById, new { RequestId = entity.RequestId });
                if (query != null)
                {
                    await Task.Run(() => entity.Amount = query.Amount);
                    await Task.Run(() => entity.Currency = query.Currency);
                    await Task.Run(() => entity.Status = query.Status);
                }
                else
                {
                    await Task.Run(() => entity.Currency = "not found");
                    await Task.Run(() => entity.Status = "not found");
                }
            });

        }

        public async Task<IEnumerable<Product>> GetByIdAddress(Product entity) 
        {
            return await WithConnection(async conn =>
            {
                var query = await conn.QueryAsync<Product>(_commandText.GetProductByIdAddress, new { ClientId = entity.ClientId, DepartmentAddress = entity.DepartmentAddress });
                return query;
            });

        }
       
        public async Task AddProduct(Product entity)
        {
            
            await WithConnection(async conn =>
            {
                int? userId = conn.Query<int>(_commandText.AddProduct, 
                    new { ClientId = entity.ClientId, DepartmentAddress = entity.DepartmentAddress, Amount = entity.Amount, Currency = entity.Currency }).FirstOrDefault();
                await Task.Run(() => entity.RequestId = userId.Value);
            });
        }
    }
}
