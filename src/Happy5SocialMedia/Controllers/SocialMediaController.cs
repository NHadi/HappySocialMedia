using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Happy5SocialMedia.Common.DTO;
using Happy5SocialMedia.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Happy5SocialMedia.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {
        private readonly IUserService _userService;
        public SocialMediaController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Get List Of USer
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("ListUser")]
        public IActionResult ListUser()
        {
            try
            {
                var responAPI = _userService.ListUser();
                return Ok(new ApiOkResponse(responAPI));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiBadRequestResponse(400, "Terjadi Kesalahan"));
            }
        }
    }
}
