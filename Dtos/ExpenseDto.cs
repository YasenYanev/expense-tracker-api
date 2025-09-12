namespace expense_tracker_api.Dtos;

public record class ExpenseDto
{
    public required string ExpenseName { get; init; }
    public required float Price { get; init; } 
    public required int ExpenseCategoryId { get; init; }
}
