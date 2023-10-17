using DomainLayer;
using DomainLayer.Models;
using DomainLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ProductRepository :Repository<Product>, IProductRepository
    {
        
        public ProductRepository(DbContext  dbContext) :base(dbContext){
        
        }

        public  async Task<Product> FindByNameAsync(string name)
        {
            
           return await _DbContext.Products.FirstAsync(p => p.Name == name); 
        }
        public override async Task<Product> FindByIdAsync(int id)
        {

            //return   _DbContext.Set<T>().SingleAsync(x=> x.Id == id); // retrive one record based on one condition
            return await _DbContext.Products
                .Include(p => p.ShoppingCartBuyList).SingleAsync(p => p.Id == id);
        }

    }
}
