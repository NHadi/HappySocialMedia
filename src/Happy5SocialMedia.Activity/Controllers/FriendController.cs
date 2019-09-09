using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Happy5SocialMedia.Activity.Application.DTO;
using Happy5SocialMedia.Activity.Domain.Services;
using Happy5SocialMedia.Common.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Happy5SocialMedia.Activity.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class FriendController : ControllerBase
    {
        private readonly IFriendService _friendService;
        public FriendController(IFriendService friendService)
        {
            _friendService = friendService;
        }
        /// <summary>
        /// Get All Friend Request
        /// </summary>
        /// <returns></returns>

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var responAPI = _friendService.ListRequest();
                return Ok(new ApiOkResponse(responAPI, responAPI.Count));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiBadRequestResponse(400, "Terjadi Kesalahan"));
            }
        }

        /// <summary>
        /// Get Friend 
        /// </summary>
        /// <param name="idUser">ID USER</param>
        /// <returns></returns>
        // GET api/values/5
        [HttpGet("{idUser}/relationship")]
        public IActionResult GetRelationship(Guid idUser)
        {
            try
            {
                var responAPI = _friendService.ListFriend(idUser);
                return Ok(new ApiOkResponse(responAPI, responAPI.Count));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiBadRequestResponse(400, "Terjadi Kesalahan"));
            }
        }


        /// <summary>
        /// Get Request Friend 
        /// </summary>
        /// <param name="idUser"></param>
        /// <returns></returns>
        [HttpGet("{idUser}/request")]
        public IActionResult GetRequest(Guid idUser)
        {
            try
            {
                var responAPI = _friendService.ListFriendRequest(idUser);
                return Ok(new ApiOkResponse(responAPI, responAPI.Count));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiBadRequestResponse(400, "Terjadi Kesalahan"));
            }
        }

        /// <summary>
        /// Send Request Friend
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] FriendRelationshipRequest request)
        {
            try
            {
                var respon = _friendService.Request(request.UserSender, request.UserReciever);
                return Ok(new ApiResponse(respon.status == true ? 200 : 400, respon.message));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiBadRequestResponse(400, "Terjadi Kesalahan"));
            }
        }

        /// <summary>
        /// Approve Friendship
        /// </summary>
        /// <param name="idRequest"></param>
        /// <returns></returns>
        [HttpGet("{idRequest}/Approve")]
        public IActionResult Approve(Guid idRequest)
        {
            try
            {
                var respon = _friendService.Approve(idRequest);
                return Ok(new ApiResponse(respon.status == true ? 200 : 400, respon.message));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiBadRequestResponse(400, "Terjadi Kesalahan"));
            }
        }
    }
}
