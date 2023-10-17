using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.services
{
    public class SpecialOfferService:Service<SpecialOffer>
    {
        public SpecialOfferService(IUnitOfWork unitOfWork):base(unitOfWork){}

        public override async Task<bool> CreateOrUpdateAsync(SpecialOffer s)
        {
            if (await base.CreateOrUpdateAsync(s))
            {
                Console.WriteLine($"Special Offer '{s.Name}' successfuly saved!");
                return true;
            }

            else
            {
                Console.WriteLine("Error saving manager!");
                return false;
            }
        }

        public async override Task<bool> DeleteAsync(SpecialOffer s)
        {
            if (await base.DeleteAsync(s))
            {
                Console.WriteLine($"Special Offer '{s.Name}' successfuly deleted!");
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
