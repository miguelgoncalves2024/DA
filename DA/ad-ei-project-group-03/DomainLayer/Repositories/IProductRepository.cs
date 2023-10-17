using DomainLayer.Models;
using DomainLayer.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;         
using System.Threading.Tasks;

namespace DomainLayer.Repositories
{
    public interface IProductRepository: IRepository<Product>
    {
        Task<Product> FindByNameAsync(string name);
        Task<Product> FindByIdAsync(int id);
        // Task<List<Product>> FindAllProductsByUserIdAsyn(int userId);
        //Task<Product>  FindDuplicateAsync(string name);

    }
}
