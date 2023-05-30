using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ObjectMappings.Models;
using ObjectMappings.Services;

namespace ObjectMappings.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public UsersController(ILogger<UsersController> logger, IMapper mapper, IUserService userService)
        {
            _logger = logger;
            _mapper = mapper;
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetUserDetails()
        {
            var user = _userService.GetUser();
            //simple mapping
            UserDto userdto = _mapper.Map<UserDto>(user);

            //mapping with different names
            UserDtoDifferentNames userDtoDifferentNames = _mapper.Map<UserDtoDifferentNames>(user);
            return Ok(userdto);
        }
    }
}
