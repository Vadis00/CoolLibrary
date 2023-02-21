using AutoMapper;
using CoolLibrary.BLL.Service.Abstract;
using CoolLibrary.DAL;

namespace CoolLibrary.BLL.Service
{
    public class AuthorizationService
    {
        private readonly string _secretKey;

        public AuthorizationService(IConfiguration configuration)
        {
            _secretKey = configuration["Secret:Key"];
        }

        public bool isUserAuthorized(string secretKey)
        {
            if (_secretKey == secretKey)
                return true;

            return false;
        }
    }
}