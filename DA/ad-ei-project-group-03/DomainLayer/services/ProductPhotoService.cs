using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer.services
{
    public class ProductPhotoService : Service<ProductPhoto>
    {
        public ProductPhotoService(IUnitOfWork unitOfWork) : base(unitOfWork) { }
    }
}
