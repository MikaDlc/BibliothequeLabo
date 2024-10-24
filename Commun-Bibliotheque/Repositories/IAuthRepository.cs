﻿using Commun_Bibliotheque.Entities;

namespace Commun_Bibliotheque.Repositories
{
    public interface IAuthRepository<TAuth> where TAuth : IAuth
    {
        public bool Register(string email, string password, string name, string firstName, bool isAdmin = false);
        public TAuth Login(string email, string password);
        public string GetPassword(string email);
    }
}
