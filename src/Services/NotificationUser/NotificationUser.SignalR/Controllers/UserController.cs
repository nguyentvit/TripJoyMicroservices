using Microsoft.AspNetCore.Mvc;
using NotificationUser.SignalR.Dtos;

namespace NotificationUser.SignalR.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController
        (IUserRepository repository): ControllerBase
    {
        [HttpGet("{userId}")]
        public async Task<ActionResult<UserResponseDto>> GetUsers(Guid userId)
        {
            var user = await repository.GetUser(userId);
            return Ok(user);
        }
        [HttpPost]
        public async Task<ActionResult<bool>> CreateUser([FromBody] UserCreateDto request)
        {
            var user = new User(request.UserId);
            await repository.CreateUser(user);
            return Ok(true);
        }
        [HttpPost("friend")]
        public async Task<ActionResult<bool>> CreateFriend([FromBody] FriendRequest request)
        {
            await repository.AddFriend(request.UserIdFirst, request.UserIdSecond);
            return Ok(true);
        }
    }
}
