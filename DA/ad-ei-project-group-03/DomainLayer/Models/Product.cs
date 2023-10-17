using DomainLayer.SeedWork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class Product : Entity
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int Stock { get; set; }
        public string Provider { get; set; }
        public int CategoryId { get; set; }// foreign key properity (Miguel:Why do we need category and category id?)
        public Category Category { get; set; }   //navigation properity
        //public ProductPhoto ProductPhoto { get; set; }
        //public int ProductPhotoId { get; set; }

        public List<SpecialOffer> SpecialOffers { get; set; }

        //[NotMapped]
        //public List<Product>Products { get; set; }


        public  List<BuyProduct> ShoppingCartBuyList { get; set; }
        public Product(){}
        public Product(string name, float price,string description,
            DateTime exp,int stock,string provider,Category category)
        {
            Name = name;
            Price = price;
            Description = description;
            ExpirationDate = exp;
            Stock = stock;
            Provider = provider;
            Category = category;
            CategoryId = category.Id;
            //ProductPhoto = new ProductPhoto();
           // ProductPhotoId =ProductPhoto.Id;
            List<SpecialOffer> SpecialOffers = new List<SpecialOffer>();
        }
        
        public bool AddSpecialOffer(SpecialOffer special_offer)
        {
            SpecialOffers = new List<SpecialOffer>();
            
            SpecialOffers.Add(special_offer);

            if (SpecialOffers.Contains(special_offer))
            {
                return true;
            }

            else
            {
                Console.WriteLine("Error adding a special offer.");
                return false;
            }
           
        }
            
        public bool isOutOfStock()
        {
            if (Stock <= 0) 
            { 
                return true; 
            }
            else return false;
        }
        
    }
}
