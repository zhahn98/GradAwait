using GradAwait.Models.DTOs;

namespace GradAwait.Models.DTOs;

public class ReactionsDTO
{
  public int UserId { get; set; }
  public UserProfileDTO User { get; set; }
  public int MsgId { get; set; }
  public int Id { get; set; }
  public int ReactionTypeId { get; set; }
}
