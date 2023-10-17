using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.services
{
    public class CategoryService:Service<Category>
    {
        public CategoryService(IUnitOfWork unitOfWork):base(unitOfWork){}

        public override async Task<bool> CreateOrUpdateAsync(Category c)
        {
            
            if (await base.CreateOrUpdateAsync(c))
            {
               
                _uow.CategoryRepository.Create(c);
                Console.WriteLine($"Category '{c.Name}' successfuly saved!");
              //  await _uow.SaveChangesAsync();
                return true;
            }
            
            else
            {
                Console.WriteLine("Error saving category!");
                return false;
            }
        }

        public async override Task<bool> DeleteAsync(Category c)
        {
            if(c.Produtos.Any())
            {
                Console.WriteLine("You can´t delete a category that is releated to one or more products");
                return false;
            }

            else if (await base.DeleteAsync(c))
            {
                Console.WriteLine($"Category '{c.Name}' successfuly deleted!");
                return true;
            }
            
            else
            {
                Console.WriteLine("Error deleating category!");
                return false;
            }
        }
    }
}
