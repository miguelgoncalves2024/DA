using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer.services
{
    public class BuyProductService:Service<BuyProduct>
    {
        public BuyProductService(IUnitOfWork unitOfWork):base(unitOfWork){}



    }
}
