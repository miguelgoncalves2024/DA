using DomainLayer.Models;
using DomainLayer.Repositories;
using DomainLayer.SeedWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ClientRepository : Repository<Client>, IClientRepository
    {
        public ClientRepository(DbContext dbContext) : base(dbContext){ }

        public async Task<Client> FindByNumberCardAsync(int number)
        {
            using(var context = new DbContext())
            {
                var query = context.Clients
                                    .SingleAsync(c => c.CardNumber == number);
                
              return await query;
            }

           
        }
    }
}
