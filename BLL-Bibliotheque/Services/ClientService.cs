﻿using BLL_Bibliotheque.Entities;
using BLL_Bibliotheque.Mapper;
using Commun_Bibliotheque.Repositories;
using DAL = DAL_Bibliotheque.Entities;

namespace BLL_Bibliotheque.Services
{
    public class ClientService : IClientRepository<Client>
    {
        private IClientRepository<DAL.Client> _Service;
        public ClientService(IClientRepository<DAL.Client> Service)
        {
            _Service = Service;
        }


        public IEnumerable<Client> Get()
        {
            return _Service.Get().Select(c => c.ToBLL());
        }

        public Client Get(int id)
        {
            return _Service.Get(id).ToBLLDetails();
        }

        public int Insert(Client entity)
        {
            return _Service.Insert(entity.ToDAL());
        }


        public void Update(int id, Client entity)
        {
            _Service.Update(id, entity.ToDAL());
        }
        public void EmailUpdate(int id, string email)
        {
            _Service.EmailUpdate(id, email);
        }
        public void PasswordUpdate(int id, string password)
        {
            _Service.PasswordUpdate(id, password);
        }
    }
}
