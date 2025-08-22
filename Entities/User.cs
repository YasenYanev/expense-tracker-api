namespace expense_tracker_api.Entities;

public class User
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string HashedPassword { get; set; }
}
