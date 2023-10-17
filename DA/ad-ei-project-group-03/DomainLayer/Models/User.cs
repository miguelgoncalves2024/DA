using System;
using System.Collections.Generic;
using System.Text;
using DomainLayer.SeedWork;

namespace DomainLayer.Models
{
    public abstract class User:Entity
    {
       public string Name { get; set; }
       public string Address { get; set; }
       public string Email { get; set; }
       public string Password { get; set; }
       public string PhoneNumber{ get; set; }
        
        public User() { }
        public User(string name,string address,string email,string password,string phone)
        //:base(id)
        {
            Name = name;
            Address = address;
            Email = email;
            Password = password;
            PhoneNumber = phone;
        }
    }

    public class Client :User
    {
        public int CardNumber { get; set; }
        public ShoppingCart Cart { get; set; }
        
        public int ShoppingCartId { get; }
        public List<SpecialOffer> SpecialOfferList { get; set; }

        public Client():base(){}

        public Client(string name, string address, string email, 
                      string password, string phone, int card, ShoppingCart Cart)
                      :base(name,address,email,password,phone)
        { 
            CardNumber = card;
            this.Cart = Cart;
            this.Id = base.Id;
            ShoppingCartId = Cart.Id;
        }

        public bool AddProductToShoppingCart(Product p, int quantity)
        {
            if (Cart.addProduct(p, quantity))
            {
                return true;
            }

            else return false;
        }

        /*public bool AddSpecialOfer(int id)
       {

       }*/
    }

    public class Manager : User 
    {
        public Manager() : base(){}
        public float Salary { get; set; }
 
        public Manager( string name, string address, string email, string password, string phone, float salary)
        : base(name, address, email, password, phone)
        {
            this.Id = base.Id;
            Salary = salary;
        }
    }

}
