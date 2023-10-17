using DomainLayer.SeedWork;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer.Models
{
    public class GiveSpecialOffer:Entity
    {
        public SpecialOffer SpecialOffer { get; set; }
        public int idSpecialOffer { get; }
        public Client client { get; set; }
        public int idClient;

        public GiveSpecialOffer(SpecialOffer specialOffer,Client client)
        {
            SpecialOffer = specialOffer;
            idSpecialOffer = specialOffer.Id;
            this.client = client;
            idClient = client.Id;
        }
    }
}
