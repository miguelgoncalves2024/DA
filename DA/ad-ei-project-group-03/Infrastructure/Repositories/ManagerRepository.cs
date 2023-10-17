using DomainLayer.Models;
using DomainLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
    public class ManagerRepository: Repository<Manager>, IManagerRepository
    {
        public ManagerRepository(DbContext dbContext) : base(dbContext) { }

    }
}
