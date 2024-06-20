namespace GradAwait.Models.DTOs;

public class RegistrationDTO
{
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? UserName { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Address { get; set; }
    public string? imageUrl { get; set; }
    public string? linkedInUrl { get; set; }
    public string? description { get; set; }
    // project id?
    public string? funFact { get; set; }
    public bool isSubscribed { get; set; }
    // is admin?
}
