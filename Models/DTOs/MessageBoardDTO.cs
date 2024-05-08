using GradAwait.Models.DTOs;

namespace GradAwait.Models.DTOs;

public class MessageBoardDTO
{
  public int UserId { get; set; }
  public UserProfileDTO User { get; set; }
  public int Id { get; set; }
  public string Message { get; set; }
  public string Image { get; set; }
  public string Date { get; set; }
}
