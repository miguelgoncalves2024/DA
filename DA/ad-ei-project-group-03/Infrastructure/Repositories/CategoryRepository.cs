using DomainLayer.Models;
using DomainLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class CategoryRepository: Repository<Category>, ICategoryRepository
    {
       public CategoryRepository(DbContext dbContext) : base(dbContext){}

       public async Task<Category> FindByNameAsync(string name)
       {
            using(var context = new DbContext())
            {
                var query = context.Categories
                                    .SingleAsync(c =>c.Name == name);
                
              return await query;
            }
       }

   
    }
}
