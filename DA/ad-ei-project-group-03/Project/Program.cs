using DomainLayer;
using DomainLayer.Models;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Xml.Linq;
using System.Threading;
using DomainLayer.services;
using System.Net;
using System.Numerics;

namespace Project
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            using(IUnitOfWork uow = new UnitOfWork())
            {
                try
                {
                    DateTime date = new DateTime(2050, 8, 12);

                    ClientService service_client = new ClientService(uow);
                    Client client = new Client("Miguel", "Bragança", "mprg2003@gmail.com",
                      "password", "938946732", 15236, new ShoppingCart());

                    CategoryService service_category = new CategoryService(uow);
                    Category category = new Category("food", "All kind of food!");

                    ManagerService service_manager = new ManagerService(uow);
                    Manager manager = new Manager("Pedro", "Vila Real", "pedroalbertino@gmail.com", "**********", "872696823", 540.99f);

                    ProductService service_product = new ProductService(uow); ;
                    Product product = new Product("leite mimosa", 1.99f, "a package of most quality milk",
                    date, 30, "Mimosa", category);

                    await service_category.CreateOrUpdateAsync(category);



                    await service_product.CreateOrUpdateAsync(product);
                    await service_product._uow.ProductRepository.FindAllAsync();
                    await service_product.CreateOrUpdateAsync(product);
                    await service_product.DeleteAsync(product);

                } 
                catch(NullReferenceException)
                {
                    Console.WriteLine("We just add an exeption, looks like our entity its not properly referenced");
                }
               
                
                
            }

            /*using (IUnitOfWork uow = new UnitOfWork())
            {
                var task_product = await uow.ProductRepository.FindByIdAsync(product.Id);//find the product
                var task_specialoffer = uow.SpecialOfferRepository.FindByIdAsync(specialOffer.Id);//find the special offer

                uow.ProductRepository.Create(product);
                    //if (uow.ProductRepository.Create(product))
                    //{
                    //    //We will soon creat a function to create product photo
                    //}

                    uow.SpecialOfferRepository.Create(specialOffer);

                    Thread.Sleep(4000);

                    if (product.Id == task_product.Id)
                    {
                        if (client.Cart.addProduct(product, 20))
                        {
                            Console.WriteLine("product succesfully added to the shopping cart.");
                        }

                        client.Cart.setTotalValue();
                        Console.WriteLine("Total value to pay: ", client.Cart.TotalValue);

                        if (client.Cart.purchase())
                        {
                            Console.WriteLine("Purchase successfuly done.");
                        }

                        if (client.Cart.RemoveProduct(product, 14))
                        {
                            Console.WriteLine("Product successfuly removed.");
                        }
                    }
                

                
                if (specialOffer.Id == task_specialoffer.Result.Id)
                {
                if (product.AddSpecialOffer(specialOffer))
                    {
                        Console.WriteLine("SpecialOffer added successfuly.");
                    }
                }
                else Console.WriteLine("Special Offer invalid ID.");

                //update operations
                uow.ProductRepository.Update(product);
                uow.SpecialOfferRepository.Update(specialOffer);

                //read operations
                uow.ProductRepository.FindAllAsync();
                uow.SpecialOfferRepository.FindAllAsync();

                //delete operations
                //if I delete a product I delete its photo as well
                uow.ProductRepository.Delete(product);
                //if (uow.ProductRepository.DeleteProduct(product))
                //{
                //   // uow.ProductPhotoRepository.Delete(product.ProductPhoto);
                //}

                uow.SpecialOfferRepository.Delete(specialOffer);
            }*/
        }
    }
}
