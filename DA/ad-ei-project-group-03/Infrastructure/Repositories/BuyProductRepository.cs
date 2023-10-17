using DomainLayer;
using DomainLayer.Models;
using DomainLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
    public class BuyProductRepository: Repository<BuyProduct>,IBuyProductRepository
    {
        public BuyProductRepository(DbContext dbContext):base(dbContext)
        {
        }
    }
}
