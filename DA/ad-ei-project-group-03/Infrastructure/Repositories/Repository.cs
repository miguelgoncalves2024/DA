using DomainLayer.Models;
using DomainLayer.SeedWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T:Entity //GENERIC REPO FOR ALL
    {
        protected DbContext _DbContext;

        public Repository(DbContext dbContext)
        {
            _DbContext = dbContext;
        }
        public bool Create(T e)
        {
            _DbContext.Add(e);// it is not async because you are not sending data to db just saving to memory.Data is being send to data while save method thats why it is async.
            return true;
        }

        public bool Delete(T e)
        {
            _DbContext.Remove(e);
            return true;
        }

        public void Update(T e)
        {
            _DbContext.Update(e);
        }
        public virtual async Task<T> FindByIdAsync(int id)
        {
            
            //return   _DbContext.Set<T>().SingleAsync(x=> x.Id == id); // retrive one record based on one condition
            return await _DbContext.Set<T>().FindAsync(id);
        }

        public virtual async Task<List<T>> FindAllAsync()
        {

            return await _DbContext.Set<T>().ToListAsync();
        }

    }
}
