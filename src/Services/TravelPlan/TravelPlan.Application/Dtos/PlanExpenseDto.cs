namespace TravelPlan.Application.Dtos
{
    public record PlanExpenseDto(decimal Expense, decimal Excess, int TotalCount ,List<ExpenseResponseDto> DetailExpense);
}
