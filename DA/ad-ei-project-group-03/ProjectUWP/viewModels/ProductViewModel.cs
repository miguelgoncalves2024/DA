
using DomainLayer.Models;
using DomainLayer.services;
using DomainLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure;

namespace ProjectUWP.viewModels
{
    public class ProductViewModel
    {
        public ObservableCollection<Product> Products { get; set; }
        public ProductService ProductService { get; set; }
        public Product product { get; set; }//for the textbox inside the category name
        IUnitOfWork _uow;
        public ProductViewModel()
        {
            Products = new ObservableCollection<Product>();
            _uow = new UnitOfWork();
            product = new Product();
            ProductService = new ProductService(_uow);

        }
        public async void LoadAllAsync()
        {
            // var uow = new UnitOfWork();
            var cats = await _uow.ProductRepository.FindAllAsync();
            Products.Clear();
            foreach (var c in cats)
            {
                Products.Add(c);
            }
        }
        public async Task<bool> CreateCategoryAsync()
        {
          

            return await ProductService.CreateOrUpdateAsync(product);
        }
    }
}
