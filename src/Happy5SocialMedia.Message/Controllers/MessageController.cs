using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Happy5SocialMedia.Common.DTO;
using Happy5SocialMedia.Message.Application.DTO;
using Happy5SocialMedia.Message.Domain.Model.Repositories.Interface;
using Happy5SocialMedia.Message.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Happy5SocialMedia.Message.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;
        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        /// <summary>
        /// Get Conversation User
        /// </summary>
        /// <param name="idUser"></param>
        /// <returns></returns>
        [HttpGet("{idUser}/ReadConversation")]
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
        [HttpGet("{idConversation}/ReadMessages")]
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

        /// <summary>
        /// Send Message to Another User
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        // POST api/values
        [HttpPost("SendMessage")]
        public IActionResult SendMessage([FromBody] SendMessageRequest request)
        {
            try
            {
                var respon = _messageService.SendMessage(request);
                return Ok(new ApiResponse(respon.status == true ? 200 : 400, respon.message));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiBadRequestResponse(400, "Terjadi Kesalahan"));
            }
        }     
    }
}
