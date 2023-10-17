using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.services
{
    public class ProductService:Service<Product>
    {
        public ProductService(IUnitOfWork unit):base(unit){}

        public override async Task<bool> CreateOrUpdateAsync(Product p)
        {
            bool isNew = p.Id == 0;

            

            if (await base.CreateOrUpdateAsync(p))
            {
                _uow.ProductRepository.Create(p);
                Console.WriteLine($"Product '{p.Name}' successfuly saved!");
               
                if(!isNew && p.SpecialOffers.Count!=0)
                {
                    UpdateBuyProductAndSpecialOffer(p);
                    return true;
                }

                return true;

                /*if(_uow.ProductPhotoRepository.Create(p.ProductPhoto))
                {
                        await _uow.SaveChangesAsync();
                        return true;
                }
                
                else return false;*/
                
            }

            else
            {
                Console.WriteLine("Error saving product!");
                return false;
            }
        }

        public async override Task<bool> DeleteAsync(Product p)
        {
            if (await base.DeleteAsync(p))
            {
                try
                {
                    /*if (_uow.ProductPhotoRepository.Delete(p.ProductPhoto))
                    {
                        await _uow.SaveChangesAsync();
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Error deleating product's photo!");
                        return false;
                    }*/

                    return true;
                
                }

                catch (NullReferenceException)
                {
                    Console.WriteLine("WARNING: NullReferenException. We have no product photo to delete.");
                    return false;
                }
            }

            else
            {
                Console.WriteLine("Error deleting product!");
                return false;
            }
        }

        private async void UpdateBuyProductAndSpecialOffer(Product p)
        {
            foreach(var item in p.SpecialOffers)
            {
                _uow.SpecialOfferRepository.Update(item);
            }

            await _uow.SaveChangesAsync();
        }
    }
}
