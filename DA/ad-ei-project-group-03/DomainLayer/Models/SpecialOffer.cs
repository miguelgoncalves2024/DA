using DomainLayer.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer.Models
{
    public class SpecialOffer:Entity
    {
        public DateTime ExpirationDate { get; set; }
        public float Discount { get; set; }
        public Product Product { get;}
        public int ProductId { get;}
        public string Name { get; set; }
        public string Description { get; set; }

        public SpecialOffer() { }
        public SpecialOffer( DateTime ExpirationDate, float Discount, Product product, string Name, string Description)
        {
            this.ExpirationDate = ExpirationDate;
            this.Discount = Discount;
            this.Product = product;
            this.ProductId = product.Id;
            this.Name = Name;
            this.Description = Description;
        }
    }
}
