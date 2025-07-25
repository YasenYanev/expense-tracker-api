namespace expense_tracker_api.Entities;

public class Expense
{
    public int ID { get; set; }
    public string ExpenseName { get; set; }
    public float Price { get; set; }
    public int ExpenseCategoryId { get; set; }
    public ExpenseCategory ExpenseCategory { get; set; }
    public DateOnly Date { get; set; }
}
