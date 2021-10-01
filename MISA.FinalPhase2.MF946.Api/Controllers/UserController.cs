using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.ApplicationCore.Interfaces.Repositories;
using MISA.ApplicationCore.Interfaces.Services;
using MISA.Entity.MISA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.FinalPhase2.MF946.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : BaseEntityController<User>
    {
        #region Declares
        private readonly IUserService _userService;
        private readonly IUserRepository _userRepository;
        #endregion

        #region Constructor
        public UserController(IUserService userService,
            IUserRepository userRepository) : base(userService, userRepository)
        {
            _userService = userService;
            _userRepository = userRepository;
        }
        #endregion
    }
}
