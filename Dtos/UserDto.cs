namespace expense_tracker_api.Dtos;
using System.ComponentModel.DataAnnotations;

public record class UserDto
{
    [RegularExpression(@"^[a-zA-Z0-9]{3,27}$",
        ErrorMessage = "Username must be 3-27 characters and contain only letters and numbers.")]
    public required string UserName { get; init; }
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*()_+\-=\[\]{};':""\\|,.<>\/?]).{12,64}$",
        ErrorMessage = "Password must be 12-64 characters long and contain uppercase, lowercase, number, and special character.")]
    public required string Password { get; init; }
};
