using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Happy5SocialMedia.Common.DTO;
using Happy5SocialMedia.DTO;
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

        #region User
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
        /// <summary>
        /// Get List Subordinates of User
        /// </summary>
        /// <param name="idUser"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("ListUserSubordinates")]
        public IActionResult GetUserSubordinates(Guid idUser)
        {
            try
            {
                var responAPI = _userService.ListSubordinates(idUser);
                return Ok(new ApiOkResponse(responAPI, responAPI.Count));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiBadRequestResponse(400, "Terjadi Kesalahan"));
            }
        }
        /// <summary>
        /// Get List Parent Of User
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("ListUserParents")]
        public IActionResult GetUserParent(Guid id)
        {
            try
            {
                var responAPI = _userService.ListParents(id);
                return Ok(new ApiOkResponse(responAPI, responAPI.Count));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiBadRequestResponse(400, "Terjadi Kesalahan"));
            }
        }
        /// <summary>
        /// Add User
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddUser")]
        public IActionResult AddUser([FromBody] AccountUserCreateRequest request)
        {
            try
            {
                var responAPI = _userService.Add(request);
                return Ok(responAPI);
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiBadRequestResponse(400, "Terjadi Kesalahan"));
            }
        }
        [HttpPut]
        [Route("UpdateUser")]        
        public IActionResult UpdateUser(Guid id, [FromBody] AccountUserUpdateRequest request)
        {
            try
            {
                var respond = _userService.Update(id, request);
                return Ok(respond);
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiBadRequestResponse(400, "Terjadi Kesalahan"));
            }
        }
        [HttpDelete]
        [Route("DeleteUser")]
        public IActionResult DeleteUser(Guid id)
        {
            try
            {
                var respond = _userService.Delete(id);
                return Ok(respond);
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiBadRequestResponse(400, "Terjadi Kesalahan"));
            }
        }
        #endregion
    }
}
