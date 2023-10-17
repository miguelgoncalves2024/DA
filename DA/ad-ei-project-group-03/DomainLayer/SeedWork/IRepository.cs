using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.SeedWork
{
    public interface IRepository<T> where T : Entity
    {
        bool Create(T e);

        void Update(T e);

        bool Delete(T e);

        Task<List<T>> FindAllAsync();

        Task<T> FindByIdAsync(int id);
    }
}
