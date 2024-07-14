using GradAwait.Models.DTOs;

namespace GradAwait.Models.DTOs;

public class NewsLetterDTO
{
  public int Id { get; set; }
  public int UserId { get; set; }
  public UserProfileDTO? User { get; set; }
  public string Title { get; set; }
  public string Body { get; set; }
  public string Image { get; set; }
  public string Date { get; set; }
}
