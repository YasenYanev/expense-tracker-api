namespace expense_tracker_api.Services.Interfaces;

public interface IJWTServiceTest
{
    public string GenerateToken(string username, string role);
}
