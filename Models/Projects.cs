using Microsoft.AspNetCore.Identity;

namespace GradAwait.Models;

public class Projects
{
  public int Id { get; set; }
  public int UserId { get; set; }
  public string ProjectName { get; set; }
  public string Description { get; set; }
  public string Url { get; set; }
}
