using GradAwait.Models.DTOs;

namespace GradAwait.Models.DTOs;

public class ProjectDTO
{
  public int Id { get; set; }
  public int UserId { get; set; }
  public UserProfileDTO? User { get; set; }
  public string ProjectName { get; set; }
  public string Description { get; set; }
  public string Url { get; set; }
}
