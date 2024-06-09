using GradAwait.Data;
using GradAwait.Models;
using GradAwait.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GradAwait.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReactionsController : ControllerBase
{
    private GradAwaitDbContext _dbContext;
    public ReactionsController(GradAwaitDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet("{reactionsId}")]
    // [Authorize]
    public IActionResult GetReaction(int? reactionsId)
    {
        if (reactionsId != null)
        {
            // get the reaction
            Reactions? reaction = _dbContext.Reaction.FirstOrDefault((re) => re.Id == reactionsId);

            if (reaction == null) return BadRequest();


            // convert it to a DTO (this is an object)
            ReactionsDTO reactionsDTO = new ReactionsDTO
            {
                Id = reaction.Id,
                MsgId = reaction.MsgId,
                ReactionTypeId = reaction.ReactionTypeId,
            };

            return Ok(reactionsDTO);
        }

        return BadRequest();
    }

    [HttpGet]
    // [Authorize]
    public IActionResult GetReactions()
    {
        // gets ALL the reaction type in an array(list)
        List<Reactions>? reactions = _dbContext.Reaction.ToList();

        // convert the reaction type (array) to a DTO version
        List<ReactionsDTO>? reactionsDTO = reactions.Select((reaction) => new ReactionsDTO
        {
                Id = reaction.Id,
                MsgId = reaction.MsgId,
                ReactionTypeId = reaction.ReactionTypeId,
        }).ToList();

        // return to list
        return Ok(reactionsDTO);
    }

    [HttpPost]
    // [Authorize]
    public IActionResult AddReaction(ReactionsDTO newReactionDTO)
    {
        // convert the 
        Reactions newReaction = new Reactions
        {
                Id = newReactionDTO.Id,
                MsgId = newReactionDTO.MsgId,
                ReactionTypeId = newReactionDTO.ReactionTypeId,
        };

        _dbContext.Reaction.Add(newReaction);
        _dbContext.SaveChanges();

        // get the id from the new instance
        int id = newReaction.Id;

        // return http status
        return Created($"api/reactiontype/{id}", newReaction);
    }

    [HttpPut("{reactionId}")]
    // [Authorize]
    public IActionResult EditReaction(int? reactionId, ReactionsDTO editedReaction)
    {
        // find the reaction to edit
        Reactions? reaction = _dbContext.Reaction.FirstOrDefault((re) => re.Id == reactionId);

        // update the values
        if (reaction != null)
        {
            // reactionType.Type = editedReactionType.Type;
            _dbContext.SaveChanges();
        }

        return NoContent();
    }

    [HttpDelete("{reactionId}")]
    // [Authorize]
    public IActionResult DeleteReaction(int? reactionId)
    {
        // find the reaction type
        Reactions? reaction = _dbContext.Reaction.FirstOrDefault((re) => re.Id == reactionId);

        if (reaction != null)
        {
            _dbContext.Reaction.Remove(reaction);
            _dbContext.SaveChanges();

            return NoContent();
        }

        return BadRequest();
    }
}
