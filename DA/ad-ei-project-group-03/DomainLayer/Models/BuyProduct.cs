using DomainLayer.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer.Models
{
    public class BuyProduct: Entity
    {
        public int ProductId { get; set; }//foreign key
        public Product Product { get; set; }
        public int ShoppingCartId { get; set; }// foreign key
        public ShoppingCart ShoppingCart { get; set; }
        public int Quantity { get; set; }
        
        public BuyProduct() { }
        public BuyProduct(Product product,ShoppingCart shoppingCart, int quantity) 
        {
            Product = product;
            ProductId= product.Id;
            ShoppingCart = shoppingCart;
            ShoppingCartId= shoppingCart.Id;    
            Quantity= quantity;
        }
    }
}
