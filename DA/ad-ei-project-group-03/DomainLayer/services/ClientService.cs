using DomainLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DomainLayer.services
{
    public class ClientService:Service<Client> //We need to make sure when we create a client, we create his/her shopping cart
    {
        public ClientService(IUnitOfWork unitOfWork) : base(unitOfWork) {}

        public override async Task<bool> CreateOrUpdateAsync(Client c)
        {
            if (await base.CreateOrUpdateAsync(c))
            {
                Console.WriteLine($"Client '{c.Name}' successfuly saved!");
                
                if(_uow.ClientRepository.FindByNumberCardAsync(c.CardNumber)==null)
                {
                   if(_uow.ShoppingCartRepository.Create(c.Cart))
                   {
                        await _uow.SaveChangesAsync();
                        return true;
                   }
                    
                   else
                   {
                        Console.WriteLine("Error: the client shopping cart was NOT successfuly created");
                        return false;
                   }
                }
               
                return true;
            }
            else
            {
                Console.WriteLine("Error  client!");
                return false;
            }
        }

        public async override Task<bool> DeleteAsync(Client c)
        {
            if (await base.DeleteAsync(c))
            {
                Console.WriteLine($"Client '{c.Name}' successfuly deleted!");
                if(_uow.ShoppingCartRepository.Delete(c.Cart))
                {
                    await _uow.SaveChangesAsync();
                    return true;
                }
                else
                {
                    Console.WriteLine("Error: The client shopping Cart was NOT succsessfuly deleted");
                    return false;
                }
            }
           
            else
            {
                Console.WriteLine("Error deleating category!");
                return false;
            }
        }

    }
}