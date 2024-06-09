using GradAwait.Data;
using GradAwait.Models;
using GradAwait.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GradAwait.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectController : ControllerBase
{
    private GradAwaitDbContext _dbContext;
    public ProjectController(GradAwaitDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet("{projectId}")]
    // [Authorize]
    public IActionResult GetProject(int? projectId)
    {
        if (projectId != null)
        {
            // get the project
            Projects? project = _dbContext.Project.FirstOrDefault((rt) => rt.Id == projectId);

            // convert it to a DTO (this is an object)
            ProjectDTO projectDTO = new ProjectDTO
            {
                Id = project.Id,
                UserId = project.UserId,
                ProjectName = project.ProjectName,
                Description = project.Description,
                Url = project.Url,
            };

            return Ok(projectDTO);
        }

        return BadRequest();
    }

    [HttpGet]
    // [Authorize]
    public IActionResult GetProjects()
    {
        // gets ALL the reaction type in an array(list)
        List<Projects>? projects = _dbContext.Project.ToList();

        // convert the reaction type (array) to a DTO version
        List<ProjectDTO>? projectsDTO = projects.Select((project) => new ProjectDTO
        {
            Id = project.Id,
            UserId = project.UserId,
            ProjectName = project.ProjectName,
            Description = project.Description,
            Url = project.Url,
        }).ToList();

        // return to list
        return Ok(projectsDTO);
    }

    [HttpPost]
    // [Authorize]
    public IActionResult AddProject(ProjectDTO newProjectDTO)
    {
        // convert the 
        Projects newProject = new Projects
        {
            Id = newProjectDTO.Id,
            UserId = newProjectDTO.UserId,
            ProjectName = newProjectDTO.ProjectName,
            Description = newProjectDTO.Description,
            Url = newProjectDTO.Url,
        };

        _dbContext.Project.Add(newProject);
        _dbContext.SaveChanges();

        // get the id from the new instance
        int id = newProject.Id;

        // return http status
        return Created($"api/project/{id}", newProject);
    }

    [HttpPut("{projectId}")]
    // [Authorize]
    public IActionResult EditProject(int? projectId, ProjectDTO editedProject)
    {
        // find the reaction type to edit
        Projects? project = _dbContext.Project.FirstOrDefault((rt) => rt.Id == projectId);

        // update the values
        if (project != null)
        {
            project.ProjectName = editedProject.ProjectName;
            project.Description = editedProject.Description;
            project.Url = editedProject.Url;
            _dbContext.SaveChanges();
        }

        return NoContent();
    }

    [HttpDelete("{projectId}")]
    // [Authorize]
    public IActionResult DeleteProject(int? projectId)
    {
        // find the reaction type
        Projects? project = _dbContext.Project.FirstOrDefault((rt) => rt.Id == projectId);

        if (project != null)
        {
            _dbContext.Project.Remove(project);
            _dbContext.SaveChanges();

            return NoContent();
        }

        return BadRequest();
    }
}
