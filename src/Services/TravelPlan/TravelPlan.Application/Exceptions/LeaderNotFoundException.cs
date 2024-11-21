namespace TravelPlan.Application.Exceptions
{
    public class LeaderNotFoundException : NotFoundException
    {
        public LeaderNotFoundException() : base("No leader not found")
        {

        }
    }
}
