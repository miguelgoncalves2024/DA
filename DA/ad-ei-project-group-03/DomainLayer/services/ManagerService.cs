using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.services
{
    public class ManagerService:Service<Manager>
    {
        public ManagerService(IUnitOfWork unitOfWork):base(unitOfWork){}

        public override async Task<bool> CreateOrUpdateAsync(Manager m)
        {
            if (await base.CreateOrUpdateAsync(m))
            {
                Console.WriteLine($"Manager '{m.Name}' successfuly saved!");
                return true;
            }

            else
            {
                Console.WriteLine("Error saving manager!");
                return false;
            }
        }

        public async override Task<bool> DeleteAsync(Manager m)
        {
            if (await base.DeleteAsync(m))
            {
                Console.WriteLine($"Manager '{m.Name}' successfuly deleted!");
                return true;
            }

            else
            {
                Console.WriteLine("Error deleating manager!");
                return false;
            }
        }
    }
}
