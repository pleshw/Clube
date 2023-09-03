using System.ComponentModel.DataAnnotations;

namespace Home.Models.User;

public class UserAccess
{
    public required Guid Id { get; set; }
    public required Guid UserId { get; set; }
    public required string Username { get; set; }
    public required string Password { get; set; }
}