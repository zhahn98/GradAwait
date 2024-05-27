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

    [HttpGet]
    [Authorize]
    public IActionResult GetReactionTypes()
    {
        // gets ALL the reaction type in an array(list)
        List<ReactionType>? reactionTypes = _dbContext.ReactionType.ToList();

        // convert the reaction type array to a DTO version
        List<ReactionTypeDTO>? reactionTypesDTO = reactionTypes.Select((reactionType) => new ReactionTypeDTO
        {
            Id = reactionType.Id,
            Type = reactionType.Type
        }).ToList();

        // return to list
        return Ok(reactionTypesDTO);
    }

    [HttpPost]
    [Authorize]
    public IActionResult AddReactionType(ReactionTypeDTO newReactionTypeDTO)
    {
        // convert the 
        ReactionType newReactionType = new ReactionType
        {
            Id = newReactionTypeDTO.Id,
            Type = newReactionTypeDTO.Type
        };

        _dbContext.ReactionType.Add(newReactionType);

        // get the id from the new instance
        int id = newReactionType.Id;

        // return http status
        return Created($"api/reactiontype/{id}", newReactionType);
    }
}