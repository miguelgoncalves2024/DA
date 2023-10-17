using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using DomainLayer.SeedWork;
using DomainLayer.services;

namespace DomainLayer.Models
{
    public class Category:Entity
    {
        public  string Name { get; set; }
        public string Description { get; set; }

        public List<Product> Produtos { get; set; }    

        public Category() { }
        public Category(string name, string description)//:base(id)
        {
            Name = name;
            Description = description;
            Produtos = new List<Product>();
        }
    
        public bool AddProductToCategory(Product p)
        {
            if(!Produtos.Contains(p))
            {
                Produtos.Add(p);
                return true;
            }

            return false;
        }


    }
}