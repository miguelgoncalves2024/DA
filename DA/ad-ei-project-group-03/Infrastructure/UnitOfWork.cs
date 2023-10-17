using DomainLayer;
using DomainLayer.Repositories;
using DomainLayer.SeedWork;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Infrastructure
{
    public class UnitOfWork:IUnitOfWork
    {
        private DbContext _DbContext;

        public IProductRepository ProductRepository => new ProductRepository(_DbContext);
        public ISpecialOfferRepository SpecialOfferRepository => new SpecialOfferRepository(_DbContext);
        public IProductPhotoRepository ProductPhotoRepository => new ProductPhotoRepository(_DbContext);
        public ICategoryRepository CategoryRepository => new CategoryRepository(_DbContext);  
        
        public IClientRepository ClientRepository => new ClientRepository(_DbContext);

        public IShoppingCartRepository ShoppingCartRepository => new ShoppingCartRepository(_DbContext);

        public IRepository<Entity> Repository => new Repository<Entity>(_DbContext);

        public IBuyProductRepository BuyProductRepository => new BuyProductRepository(_DbContext);

        public IManagerRepository ManagerRepository => new ManagerRepository(_DbContext);   
        public UnitOfWork() {
            _DbContext = new DbContext();
            _DbContext.Database.Migrate();
        }

        public void Dispose()
        {
            _DbContext.Dispose();
        }

        public async Task<int> SaveChangesAsync()
        {
            //try
            //{
                return await _DbContext.SaveChangesAsync();
            //}

            /*catch(DbUpdateException)
            {
                Console.WriteLine("WARNING: We had an DbUpdateExeption! The next changes will not be saved in the Database ");
                return -1;
            }*/
        }
    }
}
