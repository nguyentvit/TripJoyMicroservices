using Microsoft.AspNetCore.SignalR;

namespace NotificationUser.SignalR.Hubs
{
    public class NotificationHub
        (IUserRepository userRepository,
        IPlanRepository planRepository, ILogger<NotificationHub> logger) : Hub
    {
        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }
        public async Task AddNewUser(Guid UserId)
        {
            var connectionId = Context.ConnectionId;
            await userRepository.AddConnectionId(UserId, connectionId);

            var user = await userRepository.GetUser(UserId);

            if (user == null)
                throw new Exception($"User with ID {UserId} not found.");

            var onlineFriends = new List<Guid>();

            foreach (var friendId in user.FriendIds)
            {
                await Groups.AddToGroupAsync(connectionId, $"FriendsGroup-{friendId}");
                var friend = await userRepository.GetUser(friendId);
                if (friend != null)
                {
                    foreach (var friendConnectionId in friend.ConnectionIds)
                    {
                        await Groups.AddToGroupAsync(friendConnectionId, $"FriendsGroup-{UserId}");
                        await Clients.Client(friendConnectionId).SendAsync("FriendOnline", UserId);
                    }
                    if (friend.ConnectionIds.Any())
                    {
                        onlineFriends.Add(friendId);
                    }
                }
            }
            await Clients.Client(connectionId).SendAsync("OnlineFriends", onlineFriends);
        }
        public async Task SendMessage(Guid UserId, string Message, string UserName, string? Avatar)
        {
            var user = await userRepository.GetUser(UserId);
            var connectionIds = user.ConnectionIds;
            var timestamp = DateTime.UtcNow;

            foreach (var connectionId in connectionIds)
            {
                await Clients.Client(connectionId).SendAsync("ReceiveMessage", new { Message, Timestamp = timestamp, UserName, Avatar });
            }
        }
        public async Task JoinPlan(Guid UserId, Guid PlanId)
        {
            logger.LogInformation($"{UserId} join plan {PlanId}");
            var plan = await planRepository.GetPlan(PlanId);
            if (plan != null && plan.UserIds.Contains(UserId))
            {
                var connectionId = Context.ConnectionId;
                await Groups.AddToGroupAsync(connectionId, $"PlanGroup-{PlanId}");
            }
        }
        public async Task LeavePlan(Guid UserId, Guid PlanId)
        {
            logger.LogInformation($"{UserId} leave plan {PlanId}");
            var plan = await planRepository.GetPlan(PlanId);
            if (plan != null && plan.UserIds.Contains(UserId))
            {
                var connectionId = Context.ConnectionId;
                await Groups.RemoveFromGroupAsync(connectionId, $"PlanGroup-{PlanId}");
            }
        }
        public async Task SendCoordinates(Guid UserId, Guid PlanId, double Longitude, double Latitude, string UserName, string? Avatar)
        {
            var plan = await planRepository.GetPlan(PlanId);
            if (plan != null && plan.UserIds.Contains(UserId))
            {
                var connectionId = Context.ConnectionId;
                await Clients.GroupExcept($"PlanGroup-{PlanId}", new[] { connectionId }).SendAsync("ReceiveCoordinates", new { UserId, PlanId, Longitude, Latitude, UserName, Avatar });
            }
        }
        public async Task SendMessagePlan(Guid PlanId, Guid UserId, string Message, string UserName, string? Avatar)
        {
            var plan = await planRepository.GetPlan(PlanId);
            if (plan != null && plan.UserIds.Contains(UserId))
            {
                var timestamp = DateTime.UtcNow;
                var connectionId = Context.ConnectionId;
                await Clients.GroupExcept($"PlanGroup-{PlanId}", new[] { connectionId }).SendAsync("ReceiveMessagePlan", new { Message, Timestamp = timestamp, UserName, PlanId, Avatar });
            }
        }
        public async Task SendUpdatedPlan(Guid UserId, Guid PlanId, UpdateExpensePlanDto UpdateExpensePlanDto)
        {
            var plan = await planRepository.GetPlan(PlanId);
            if (plan != null && plan.UserIds.Contains(UserId))
            {
                await Clients.Group($"PlanGroup-{PlanId}").SendAsync("ReceiveUpdatedPlan", UpdateExpensePlanDto);
            }
        }
        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            var connectionId = Context.ConnectionId;
            var userId = await userRepository.RemoveConnectionId(connectionId);
            if (userId != Guid.Empty)
            {
                var user = await userRepository.GetUser(userId);
                if (user != null)
                {
                    if (user.ConnectionIds.Count == 0)
                    {
                        foreach (var friendId in user.FriendIds)
                        {
                            var friend = await userRepository.GetUser(friendId);
                            if (friend != null)
                            {
                                foreach (var friendConnectionId in friend.ConnectionIds)
                                {
                                    await Clients.Clients(friendConnectionId).SendAsync("FriendOffline", userId);
                                }
                            }
                        }
                    }

                    foreach (var friendId in user.FriendIds)
                    {
                        await Groups.RemoveFromGroupAsync(connectionId, $"FriendsGroup-{friendId}");
                    }
                }
                var plans = await planRepository.GetPlansByUserId(userId);
                foreach (var plan in plans)
                {
                    await Groups.RemoveFromGroupAsync(connectionId, $"PlanGroup-{plan.PlanId}");
                }
            }
        }

    }
}
