namespace expense_tracker_api.Entities;

public class Expenses
{
    public int Id { get; set; }
    public string ExpenseName { get; set; }
    public float Price { get; set; }
    public int ExpenseCategoryId { get; set; }
    public ExpenseCategories ExpenseCategory { get; set; }
    public DateOnly Date { get; set; }
}
