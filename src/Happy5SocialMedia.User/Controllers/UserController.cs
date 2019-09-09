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
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        /// <summary>
        /// Get All User
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var responAPI = _userService.ListUser();
                return Ok(new ApiOkResponse(responAPI, responAPI.Count));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiBadRequestResponse(400, "Terjadi Kesalahan"));
            }
        }

        /// <summary>
        /// Get User by ID
        /// </summary>
        /// <param name="id">Id User</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                var responAPI = _userService.Detail(id);
                return Ok(new ApiOkResponse(responAPI, 1));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiBadRequestResponse(400, "Terjadi Kesalahan"));
            }
        }

        /// <summary>
        /// Get Parent Of User
        /// </summary>
        /// <param name="id">ID USER</param>
        /// <returns></returns>
        [HttpGet("{Id}/Parent")]
        public IActionResult GetParent(Guid id)
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
        /// Check User Exist or not
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{Id}/UserExist")]
        public IActionResult UserExist(Guid id)
        {
            try
            {
                var responAPI = _userService.UserExist(id);
                return Ok(new ApiOkResponse(responAPI, responAPI == true ? 1 : 0));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiBadRequestResponse(400, "Terjadi Kesalahan"));
            }
        }

        /// <summary>
        /// Get subordinates Of User
        /// </summary>
        /// <param name="id">ID USER</param>
        /// <returns></returns>
        [HttpGet("{Id}/subordinates")]
        public IActionResult GetSubordinates(Guid id)
        {
            try
            {
                var responAPI = _userService.ListSubordinates(id);
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
        public IActionResult Post([FromBody] AccountUserCreateRequest request)
        {
            try
            {
               _userService.Add(request);
                return Ok(new ApiResponse(200));
            }
            catch (Exception ex)
            {                
                return BadRequest(new ApiBadRequestResponse(400, "Terjadi Kesalahan"));
            }
        }

        /// <summary>
        /// Update User
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] AccountUserUpdateRequest request)
        {
            try
            {
                _userService.Update(id, request);
                return Ok(new ApiResponse(200));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiBadRequestResponse(400, "Terjadi Kesalahan"));
            }
        }

        /// <summary>
        /// Remove User
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _userService.Delete(id);
                return Ok(new ApiResponse(200));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiBadRequestResponse(400, "Terjadi Kesalahan"));
            }
        }
    }
}
