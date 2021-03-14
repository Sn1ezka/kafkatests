using Dapper.WebApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dapper.WebApi.Services
{
    public interface IProductRepository
    {
        Task GetById(Product entity);
        Task AddProduct(Product entity);
        Task<IEnumerable<Product>> GetByIdAddress(Product entity);
        //Task<IEnumerable<Product>> GetAllProducts();
    }
}
