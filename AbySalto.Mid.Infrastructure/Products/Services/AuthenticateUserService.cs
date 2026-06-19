using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbySalto.Mid.Domain.Business.Authorization;
using AbySalto.Mid.Domain.Data.DTO;
using AbySalto.Mid.Infrastructure.Interfaces;
using AbySalto.Mid.Infrastructure.Products.Repository;

namespace AbySalto.Mid.Infrastructure.Products.Services
{
    public class AuthenticateUserService : IService<UserDto>
    {
        public bool IsAuthorized = false;
        public int UserId = -1;
        private readonly UserRepository _repository;
        private readonly Hasher _hasher;
        public AuthenticateUserService(UserRepository repository, Hasher hasher)
        {
            _repository = repository;
            _hasher = hasher;
        }

        public void Execute(ref UserDto value)
        {
            var databaseUser = _repository.GetByEmail(value.Email);
            this.IsAuthorized = databaseUser.PaswordHash == value.PaswordHash;
            this.UserId = databaseUser.Id;
        }
    }
}
