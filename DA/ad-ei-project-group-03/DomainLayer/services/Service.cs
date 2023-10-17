using DomainLayer.Models;
using DomainLayer.SeedWork;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.services
{
    public abstract class Service<T> where T: Entity
    {
        public IUnitOfWork _uow;
        
        protected Service(IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
        }

        public virtual async Task<bool> CreateOrUpdateAsync(T t)
        {
            if (t.Id != 0)
            {     
                _uow.Repository.Update(t);
                await _uow.SaveChangesAsync();
                return true;
            }
  
            
            if (_uow.Repository.Create(t))
            {
                await _uow.SaveChangesAsync();
                return true;
            }
            
            return false;
        }

        public async virtual Task<bool> DeleteAsync(T t)
        {
            if(t.Id == 0) { return false; }
            
            if(_uow.Repository.Delete(t))
            {
                await _uow.SaveChangesAsync();
                return true;
            }

            return false;
        }       
        
    }
}