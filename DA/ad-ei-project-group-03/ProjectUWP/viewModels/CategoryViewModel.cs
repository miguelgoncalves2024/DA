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
    public class CategoryViewModel
    {
        public ObservableCollection<Category> Categories { get; set; }//string is gonna be Category class object.
        public CategoryService CategoryService { get; set; }
        public Category Category { get; set; }//for the textbox inside the category name
        IUnitOfWork _uow;

        public CategoryViewModel()
        {
            Categories = new ObservableCollection<Category>();
            _uow = new UnitOfWork();
            Category = new Category();
            CategoryService = new CategoryService(_uow);

            //for (int i = 0; i < 100; i++)//demonstration delete this.
            //{
            //    Categories.Add($"item - {i}");
            //}

        }
        public async void LoadAllAsync()
        {
               // var uow = new UnitOfWork();
                var cats = await _uow.CategoryRepository.FindAllAsync();
                Categories.Clear();
                foreach (var c in cats)
                {
                    Categories.Add(c);
               }
        }

        public async Task<bool> CreateCategoryAsync()
        {
           // Categories.Add(Category);
            //_uow.CategoryRepository.Create(Category);
            //await _uow.SaveChangesAsync();
            // return true;
            return await CategoryService.CreateOrUpdateAsync(Category);
        }
    }
}
