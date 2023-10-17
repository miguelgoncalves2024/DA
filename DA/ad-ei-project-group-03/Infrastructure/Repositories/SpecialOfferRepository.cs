using DomainLayer.Models;
using DomainLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
    public class SpecialOfferRepository : Repository<SpecialOffer>, ISpecialOfferRepository
    {
        public SpecialOfferRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
