using BLL_Bibliotheque.Entities;
using BLL_Bibliotheque.Mapper;
using Commun_Bibliotheque.Repositories;
using DAL = DAL_Bibliotheque.Entities;

namespace BLL_Bibliotheque.Services
{
    public class AuthService : IAuthRepository<Auth>
    {
        private IAuthRepository<DAL.Auth> _Service;
        public AuthService(IAuthRepository<DAL.Auth> Service)
        {
            _Service = Service;
        }

        public string GetPassword(string email)
        {
            return _Service.GetPassword(email);
        }

        public Auth Login(string email, string password)
        {
            return _Service.Login(email, password).ToBLL();
        }

        public bool Register(string email, string password, string name, string firstName)
        {
            return _Service.Register(email, password, name, firstName);
        }
    }
}
