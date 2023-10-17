using DomainLayer.Models;
using DomainLayer.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Repositories
{
    public interface IClientRepository:IRepository<Client>
    {
        Task<Client> FindByNumberCardAsync(int number);
    }
}