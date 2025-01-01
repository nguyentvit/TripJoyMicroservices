namespace TravelPlan.Application.Dtos
{
    public record PlanExpenseDto(decimal TotalExpense, decimal Expense, decimal Excess, int TotalCount ,List<ExpenseResponseDto> DetailExpense);
}
