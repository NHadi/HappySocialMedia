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
        private readonly IFriendService _friendService;
        private readonly IMessageService _messageService;
        public SocialMediaController(IUserService userService, 
            IFriendService friendService,
            IMessageService messageService
            )
        {
            _userService = userService;
            _friendService = friendService;
            _messageService = messageService;
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

        #region Friend
        [HttpGet]
        [Route("ListRequest")]
        public IActionResult ListRequest()
        {
            try
            {
                var responAPI = _friendService.ListRequest();
                return Ok(new ApiOkResponse(responAPI));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiBadRequestResponse(400, "Terjadi Kesalahan"));
            }
        }
        [HttpGet]
        [Route("ListFriendRequest")]
        public IActionResult ListFriendRequest(Guid idAccountUser)
        {
            try
            {
                var responAPI = _friendService.ListFriendRequest(idAccountUser);
                return Ok(new ApiOkResponse(responAPI));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiBadRequestResponse(400, "Terjadi Kesalahan"));
            }
        }
        [HttpGet]
        [Route("ListFriend")]
        public IActionResult ListFriend(Guid idAccountUser)
        {
            try
            {
                var responAPI = _friendService.ListFriend(idAccountUser);
                return Ok(new ApiOkResponse(responAPI));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiBadRequestResponse(400, "Terjadi Kesalahan"));
            }
        }
        [HttpPost]
        [Route("ApproveRequest")]
        public IActionResult ApproveRequest(Guid idRequest)
        {
            try
            {
                var responAPI = _friendService.Approve(idRequest);
                return Ok(responAPI);
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiBadRequestResponse(400, "Terjadi Kesalahan"));
            }
        }

        [HttpPost]
        [Route("RequestFriend")]
        public IActionResult RequestFriend([FromBody] FriendRelationshipRequest Request)
        {
            try
            {
                var responAPI = _friendService.Request(Request);
                return Ok(responAPI);
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiBadRequestResponse(400, "Terjadi Kesalahan"));
            }
        }
        #endregion


        #region Message
        /// <summary>
        /// Get Conversation User
        /// </summary>
        /// <param name="idUser"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetUserConversation")]
        public IActionResult GetUserConversation(Guid idUser)
        {
            try
            {
                var responAPI = _messageService.ListUserConversation(idUser);
                return Ok(new ApiOkResponse(responAPI, responAPI.Count));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiBadRequestResponse(400, "Terjadi Kesalahan"));
            }
        }
        /// <summary>
        /// Read Message User
        /// </summary>
        /// <param name="idConversation"></param>
        /// <returns></returns>

        [HttpGet]
        [Route("GetConversationMessages")]
        public IActionResult GetConversationMessages(Guid idConversation)
        {
            try
            {
                var responAPI = _messageService.ListMessage(idConversation);
                return Ok(new ApiOkResponse(responAPI, responAPI.Count));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiBadRequestResponse(400, "Terjadi Kesalahan"));
            }
        }
        
        [HttpPost]
        [Route("SendMessage")]
        public IActionResult SendMessage([FromBody] SendMessageRequest request)
        {
            try
            {
                var respon = _messageService.SendMessage(request);
                return Ok(respon);
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiBadRequestResponse(400, "Terjadi Kesalahan"));
            }
        }
        #endregion
    }
}
