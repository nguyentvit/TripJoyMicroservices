namespace TravelPlan.Application.Dtos
{
    public record ExpenseResponseDto(
        int Order,
        string Name,
        string Address,
        decimal Amount
        );
}
