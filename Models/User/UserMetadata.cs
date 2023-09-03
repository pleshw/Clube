using System.ComponentModel.DataAnnotations;

namespace Home.Models.User;

public class UserMetadata
{
    public required Guid Id { get; set; }
    public required Guid UserId { get; set; }
    [DataType( DataType.Date )]
    public DateTime RegistrationDate { get; set; }
    [DataType( DataType.Date )]
    public DateTime LastLoginDate { get; set; }
}