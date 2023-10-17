using DomainLayer.Models;
using DomainLayer.Repositories;
using DomainLayer.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
    public class ProductPhotoRepository : Repository<ProductPhoto>, IProductPhotoRepository
    {
        public ProductPhotoRepository(DbContext dbContext) : base(dbContext)
        {
        }

    }
}
