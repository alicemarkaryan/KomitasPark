using KomitasPark.KomitasParkDAL.Entites;
using KomitasPark.KomitasParkDAL.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ProjectsController : ControllerBase
{
    private readonly IProjectRepository _projectRepository;

    public ProjectsController(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    [HttpGet]
    public IActionResult GetAllProjects()
    {
        var projects = _projectRepository.GetAll();
        return Ok(projects);
    }

    [HttpGet("{id}")]
    public IActionResult GetProject(int id)
    {
        var project = _projectRepository.GetById(id);
        if (project == null)
        {
            return NotFound();
        }
        return Ok(project);
    }

    [HttpPost]
    public IActionResult CreateProject(Project project)
    {
        _projectRepository.Add(project);
        _projectRepository.SaveChanges();
        return CreatedAtAction(nameof(GetProject), new { id = project.Id }, project);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateProject(int id, Project project)
    {
        if (id != project.Id)
        {
            return BadRequest();
        }

        _projectRepository.Update(project);
        _projectRepository.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteProject(int id)
    {
        var project = _projectRepository.GetById(id);
        if (project == null)
        {
            return NotFound();
        }

        _projectRepository.Delete(project);
        _projectRepository.SaveChanges();

        return NoContent();
    }
}