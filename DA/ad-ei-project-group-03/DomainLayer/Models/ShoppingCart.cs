using DomainLayer.SeedWork;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using System.Text;

namespace DomainLayer.Models
{
    public sealed class ShoppingCart:Client
    {
        public float TotalValue{ get; set; }
        //public int IdClient {get;}
        //public Client Client { get;}
        //public Product Product { get; set;}//navigation properity
        //[NotMapped]
        //public List<Product> Products { get; set; }
        public List<BuyProduct> shoppingCartBuyProduct{ get; set; }
        //[NotMapped]
        //public List<Quantitiy> Quantity { get; set; } //(Miguel:We want a quantity related to each products.)

        public ShoppingCart() 
        {
            shoppingCartBuyProduct = new List<BuyProduct>();
            this.Id = base.Id;
        }
        /*public ShoppingCart(Client client)
        {
            shoppingCartProducts = new List<ShoppingCartProduct>();
            Client = client;
        }*/
        public bool addProduct(Product product, int quantity)
        {
            if (product.isOutOfStock() || quantity > product.Stock)
            {
                Console.WriteLine("Sorry, we don´t have that amount in stock!");
                return false;
            }

            int index = shoppingCartBuyProduct.FindIndex(p => p.ProductId == product.Id);
             
            if(index == -1)
            {
                BuyProduct newItem = new BuyProduct(product, this, quantity);
                shoppingCartBuyProduct.Add(newItem);

                TotalValue += product.Price * quantity;

                return true;
            }
            else
            {
                if (shoppingCartBuyProduct[index].Quantity + quantity <= product.Stock)
                {
                    TotalValue += product.Price * quantity;
                    shoppingCartBuyProduct[index].Quantity += quantity;
                    return true;
                }

                else
                {
                    Console.WriteLine("Sorry, we don´t have that amount in stock!");
                    return false;
                }
            }
        }

       public bool purchase()
       {
            if (shoppingCartBuyProduct.Count == 0)
            {
                Console.WriteLine("You don't need to do a purchase, with an empty shopping cart.");
                return false;
            }

            
            foreach(var item in shoppingCartBuyProduct)
            {
               item.Product.Stock -= item.Quantity;
            }

            shoppingCartBuyProduct.Clear();
            TotalValue = 0;

            if (shoppingCartBuyProduct.Count == 0 )
            {
                return true;
            }
            else
            {
                Console.WriteLine("Error when making purchase.");
                return false;
            }
        }
    
        public bool RemoveProduct(Product product, int quantity)//Remove a product from the shopping cart
        {
            int index = shoppingCartBuyProduct.FindIndex(i => i.ProductId == product.Id);/*I find the index 
                                                                       of the product
                                                                        I want to remove*/
            if (index == -1) 
            {
                Console.WriteLine("The product you want to remove is not in the shopping cart");
                return false; 
            }
            
            if (quantity == shoppingCartBuyProduct[index].Quantity)
            {//if the quantity we want to remove is equal to the amount we have in the shopping cart

                shoppingCartBuyProduct.RemoveAt(index);
                //Quantity.RemoveAt(index); //If the products´s quantity is 0, it doesn´t make sense to keep it in our products list

                return true;
            }

            else if(quantity < shoppingCartBuyProduct[index].Quantity)
            {
                shoppingCartBuyProduct[index].Quantity -= quantity;

                return true;
            }

            else
            {
                Console.WriteLine("The shopping cart doesn't have that product quantity to remove.");
                return false;
            }
        }
    }
}
