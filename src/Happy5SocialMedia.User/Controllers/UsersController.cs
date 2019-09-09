using System;
using System.Collections.Generic;
using System.Linq;
using Happy5SocialMedia.Common.DTO;
using Happy5SocialMedia.User.Application.DTO;
using Happy5SocialMedia.User.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Happy5SocialMedia.User.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public IActionResult Users(List<Guid> id)
        {
            try
            {
                var responAPI = _userService.ListUser(id);
                return Ok(new ApiOkResponse(responAPI, responAPI.Count));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiBadRequestResponse(400, "Terjadi Kesalahan"));
            }
        }
       
    }
}
