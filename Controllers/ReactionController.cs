using GradAwait.Data;
using GradAwait.Models;
using GradAwait.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GradAwait.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReactionTypeController : ControllerBase
{
    private GradAwaitDbContext _dbContext;
    public ReactionTypeController(GradAwaitDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet("{reactionTypeId}")]
    // [Authorize]
    public IActionResult GetReactionType(int? reactionTypeId)
    {
        if (reactionTypeId != null)
        {
            // get the reaction type
            ReactionType? reactionType = _dbContext.ReactionType.FirstOrDefault((rt) => rt.Id == reactionTypeId);

            // convert it to a DTO (this is an object)
            ReactionTypeDTO reactionTypeDTO = new ReactionTypeDTO
            {
                Id = reactionType.Id,
                Type = reactionType.Type
            };

            return Ok(reactionTypeDTO);
        }

        return BadRequest();
    }

    [HttpGet]
    // [Authorize]
    public IActionResult GetReactionTypes()
    {
        // gets ALL the reaction type in an array(list)
        List<ReactionType>? reactionTypes = _dbContext.ReactionType.ToList();

        // convert the reaction type (array) to a DTO version
        List<ReactionTypeDTO>? reactionTypesDTO = reactionTypes.Select((reactionType) => new ReactionTypeDTO
        {
            Id = reactionType.Id,
            Type = reactionType.Type
        }).ToList();

        // return to list
        return Ok(reactionTypesDTO);
    }

    [HttpPost]
    // [Authorize]
    public IActionResult AddReactionType(ReactionTypeDTO newReactionTypeDTO)
    {
        // convert the 
        ReactionType newReactionType = new ReactionType
        {
            Id = newReactionTypeDTO.Id,
            Type = newReactionTypeDTO.Type
        };

        _dbContext.ReactionType.Add(newReactionType);
        _dbContext.SaveChanges();

        // get the id from the new instance
        int id = newReactionType.Id;

        // return http status
        return Created($"api/reactiontype/{id}", newReactionType);
    }

    [HttpPut("{reactionTypeId}")]
    // [Authorize]
    public IActionResult EditReactionType(int? reactionTypeId, ReactionTypeDTO editedReactionType)
    {
        // find the reaction type to edit
        ReactionType? reactionType = _dbContext.ReactionType.FirstOrDefault((rt) => rt.Id == reactionTypeId);

        // update the values
        if (reactionType != null)
        {
            reactionType.Type = editedReactionType.Type;
            _dbContext.SaveChanges();
        }

        return NoContent();
    }

    [HttpDelete("{reactionTypeId}")]
    // [Authorize]
    public IActionResult DeleteReactionType(int? reactionTypeId)
    {
        // find the reaction type
        ReactionType? reactionType = _dbContext.ReactionType.FirstOrDefault((rt) => rt.Id == reactionTypeId);

        if (reactionType != null)
        {
            _dbContext.ReactionType.Remove(reactionType);
            _dbContext.SaveChanges();

            return NoContent();
        }

        return BadRequest();
    }
}