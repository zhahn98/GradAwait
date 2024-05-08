namespace GradAwait.Models;


public class NewsLetter
{
  public int Id { get; set; }
  public int UserId { get; set; }
  public string Title { get; set; }
  public string Body { get; set; }
  public string Image { get; set; }
  public string Date { get; set; }
}
