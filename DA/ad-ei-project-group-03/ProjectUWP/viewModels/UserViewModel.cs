using DomainLayer;
using DomainLayer.Models;
using DomainLayer.services;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectUWP.viewModels
{
    public class UserViewModel
    {
        public bool ısManager=false;
        public ClientService ClientService { get; set; }
        public Client Client { get; set; }
        public Client newClient { get; set; }

        public ManagerService ManagerService { get; set; }
        public Manager  Manager { get; set; }
        public Manager newManager { get; set; }
        IUnitOfWork _uow;
        public UserViewModel() {
            _uow = new UnitOfWork();
            ManagerService = new ManagerService(_uow);
            ClientService = new ClientService(_uow);   
            Client = new Client();
            newClient = new Client();
            Manager = new Manager();
            newManager = new Manager();
        }
        public  void setC()
        {
            Client=newClient;

        }
        public void setM()
        {
            Client = newClient;

        }


        public async Task<bool> CreateCategoryAsyncClient()
        {


            return await ClientService.CreateOrUpdateAsync(newClient);
        }
        public async Task<bool> CreateCategoryAsyncManager()
        {


            return await ManagerService.CreateOrUpdateAsync(newManager);
        }

    }
}
