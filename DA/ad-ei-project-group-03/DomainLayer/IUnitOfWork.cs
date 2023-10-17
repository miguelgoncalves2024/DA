using DomainLayer.Repositories;
using DomainLayer.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer
{
    public interface IUnitOfWork: IDisposable //this is for "using" at program.cs //also implement disposable interface at unitofwork.cs because it also inherits
    {
        IProductRepository ProductRepository { get; }
        ISpecialOfferRepository SpecialOfferRepository { get; }
        IProductPhotoRepository ProductPhotoRepository { get; }
        IClientRepository ClientRepository { get; }
        IShoppingCartRepository ShoppingCartRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        IRepository<Entity> Repository { get; }
        IBuyProductRepository BuyProductRepository { get; }
        IManagerRepository ManagerRepository { get; }

        Task<int> SaveChangesAsync();// for encapsulation of db.save(); method and encapsulation method has to be async
    }
}
