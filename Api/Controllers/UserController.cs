using Application.Command.User;
using Application.Query.User;
using Domain.Aggregate;
using Domain.Command.Response;
using Domain.Entity;
using Domain.Query.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IMediator _mediatr;

        public UserController(ILogger<UserController> logger, IMediator mediatr)
        {
            _logger = logger;
            _mediatr = mediatr;
        }

        [HttpPost("CreateUser")]
        public Task<CreateUserCommandResponse> CreateUser([FromBody] UserEntity userEntity)
        {
            var command = new CreateUserCommand(userEntity);
            var commandResult = _mediatr.Send(command);
            return commandResult;
        }

        [HttpPost("GetUser")]
        public Task<GetUserResponse> GetUser([FromBody] UserEntity userEntity)
        {
            var command = new GetUserQuery(userEntity);
            var commandResult = _mediatr.Send(command);
            return commandResult;
        }

        [HttpPost("UserSendMessage")]
        public Task<UserSendMessageResponse> UserSendMessage([FromBody] Message message)
        {
            var command = new UserSendMessageCommand(message);
            var commandResult = _mediatr.Send(command);
            return commandResult;
        }
    }
}