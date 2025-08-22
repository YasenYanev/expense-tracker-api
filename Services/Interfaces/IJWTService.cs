namespace expense_tracker_api.Services.Interfaces;

public interface IJWTService
{
    public string GenerateToken(string username, int id);
}
