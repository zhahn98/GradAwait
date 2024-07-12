using GradAwait.Data;
using GradAwait.Models;
using GradAwait.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GradAwait.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NewsletterController : ControllerBase
{
  private GradAwaitDbContext _dbContext;
  public NewsletterController(GradAwaitDbContext context)
  {
    _dbContext = context;
  }

  [HttpGet("{newsletterId}")]
  // [Authorize]
  public IActionResult GetNewsLetter(int? newsLetterId)
  {
    if (newsLetterId != null)
    {
      // get the reaction type
      NewsLetter? newsLetter = _dbContext.NewsLetter.FirstOrDefault((nl) => nl.Id == newsLetterId);

      // convert it to a DTO (this is an object)
      NewsLetterDTO newsletterDTO = new NewsLetterDTO
      {
        Id = newsLetter.Id,
        UserId = newsLetter.UserId,
        Title = newsLetter.Title,
        Body = newsLetter.Body,
        Image = newsLetter.Image,
        Date = newsLetter.Date
      };

      return Ok(newsletterDTO);
    }

    return BadRequest();
  }

  [HttpGet]
  // [Authorize]
  public IActionResult GetNewsletter()
  {
    // gets ALL the reaction type in an array(list)
    List<NewsLetter>? newsLetter = _dbContext.NewsLetter.ToList();

    // convert the reaction type (array) to a DTO version
    List<NewsLetterDTO>? newsLetterDTO = newsLetter.Select((newsLetter) => new NewsLetterDTO
    {
      Id = newsLetter.Id,
      UserId = newsLetter.UserId,
      Title = newsLetter.Title,
      Body = newsLetter.Body,
      Image = newsLetter.Image,
      Date = newsLetter.Date
    }).ToList();

    // return to list
    return Ok(newsLetterDTO);
  }

  [HttpPost]
  // [Authorize]
  public IActionResult AddNewsLetter(NewsLetterDTO newsLetterDTO)
  {
    // convert the 
    NewsLetter newNewsLetter = new NewsLetter
    {
      Id = newsLetterDTO.Id,
      UserId = newsLetterDTO.UserId,
      Title = newsLetterDTO.Title,
      Body = newsLetterDTO.Body,
      Image = newsLetterDTO.Image,
      Date = newsLetterDTO.Date
    };

    _dbContext.NewsLetter.Add(newNewsLetter);
    _dbContext.SaveChanges();

    // get the id from the new instance
    int id = newNewsLetter.Id;

    // return http status
    return Created($"api/newsletter/{id}", newNewsLetter);
  }

  [HttpPut("{NewsLetterId}")]
  // [Authorize]
  public IActionResult EditNewsLetter(int? newsLetterId, NewsLetterDTO editedNewsLetter)
  {
    // find the reaction type to edit
    NewsLetter? newsLetter = _dbContext.NewsLetter.FirstOrDefault((nl) => nl.Id == newsLetterId);

    // update the values
    if (newsLetter != null)
    {
      newsLetter.UserId = editedNewsLetter.UserId;
      newsLetter.Title = editedNewsLetter.Title;
      newsLetter.Body = editedNewsLetter.Body;
      newsLetter.Image = editedNewsLetter.Image;
      newsLetter.Date = editedNewsLetter.Date;
    }

    _dbContext.SaveChanges();

    return NoContent();
  }


  [HttpDelete("{newsLetterId}")]
  // [Authorize]
  public IActionResult DeleteNewsletter(int? newsLetterId)
  {
    // find the reaction type
    NewsLetter? newsletter = _dbContext.NewsLetter.FirstOrDefault((rt) => rt.Id == newsLetterId);

    if (newsletter != null)
    {
      _dbContext.NewsLetter.Remove(newsletter);
      _dbContext.SaveChanges();

      return NoContent();
    }

    return BadRequest();
  }
}
