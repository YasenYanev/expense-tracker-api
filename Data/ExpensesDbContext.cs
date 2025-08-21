using expense_tracker_api.Entities;
using Microsoft.EntityFrameworkCore;

namespace expense_tracker_api.Data;

public class ExpensesDbContext : DbContext
{
    public ExpensesDbContext(DbContextOptions<ExpensesDbContext> options) : base(options) { }

    public DbSet<Expenses> Expenses { get; set; }
    public DbSet<ExpenseCategories> ExpensesCategories { get; set; }
    public DbSet<Users> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ExpenseCategories>().HasData(
            new { Id = 1, ExpenseCategoryName = "Groceries" },
            new { Id = 2, ExpenseCategoryName = "Leisure" },
            new { Id = 3, ExpenseCategoryName = "Electronics" },
            new { Id = 4, ExpenseCategoryName = "Utilities" },
            new { Id = 5, ExpenseCategoryName = "Clothing" },
            new { Id = 6, ExpenseCategoryName = "Health" },
            new { Id = 7, ExpenseCategoryName = "Others" }
        );
    }

}
