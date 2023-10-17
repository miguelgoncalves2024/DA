using DomainLayer.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer.Models
{
    public class ProductPhoto:Product
    {
       public byte[] photoFile { get; set;}
       
       public ProductPhoto() 
       { 
          photoFile = new byte[255];
           this.Id = base.Id;
        }
       
    }
}
