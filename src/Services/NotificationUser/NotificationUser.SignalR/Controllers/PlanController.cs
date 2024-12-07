using Microsoft.AspNetCore.Mvc;

namespace NotificationUser.SignalR.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlanController
        (IPlanRepository repository): ControllerBase
    {
        [HttpGet("{planId}")]
        public async Task<ActionResult<List<PlanResponseDto>>> GetPlan(Guid planId)
        {
            var plan = await repository.GetPlan(planId);
            return Ok(plan);
        }
        [HttpPost]
        public async Task<ActionResult<bool>> CreatePlan([FromBody] PlanCreateDto request)
        {
            var plan = new Plan(request.PlanId);
            await repository.CreatePlan(plan);
            return Ok(plan);    
        }
        [HttpPost("member")]
        public async Task<ActionResult<bool>> AddMember([FromBody] UpdateMemberDto request)
        {
            await repository.AddMember(request.PlanId, request.UserId);
            return Ok(true);
        }
        [HttpDelete("member")]
        public async Task<ActionResult<bool>> RemoveMember([FromBody] UpdateMemberDto request)
        {
            await repository.RemoveMember(request.PlanId, request.UserId);
            return Ok(true);    
        }
    }
}
