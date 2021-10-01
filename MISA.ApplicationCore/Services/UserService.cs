using MISA.ApplicationCore.Entities;
using MISA.ApplicationCore.Interfaces.Repositories;
using MISA.ApplicationCore.Interfaces.Services;
using MISA.Entity.MISA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.ApplicationCore.Services
{
    public class UserService : BaseService<User>, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ServiceResponse _serviceResponse;

        public UserService(IBaseRepository<User> baseRepository,
            IUserRepository userRepository) : base(baseRepository)
        {
            _userRepository = userRepository;
            _serviceResponse = new ServiceResponse();
        }
    }
}
