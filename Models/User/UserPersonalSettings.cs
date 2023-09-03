namespace Home.Models.User;

public class UserPersonalSettings
{
    public required Guid Id { get; set; }
    public required Guid UserId { get; set; }
    public required string ProfilePictureURL { get; set; }
    public required string DisplayName { get; set; }
}