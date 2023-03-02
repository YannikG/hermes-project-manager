using Microsoft.AspNetCore.Mvc;
using ProjectManager.Core.Entities;
using ProjectManager.Core.Services;

namespace ProjectManager.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly ProjectService _projectService;

        public ProjectsController(ProjectService projectService)
        {
            _projectService = projectService;
        }

        // GET: api/<ProjectsController>
        [HttpGet]
        public async Task<IEnumerable<ProjectEntity>> GetAsync()
        {
            return await _projectService.GetProjectsAsync();
        }

        // GET api/<ProjectsController>/5
        [HttpGet("{id}")]
        public async Task<ProjectEntity?> GetAsync(int id)
        {
            return await _projectService.GetProjectByIdAsync(id);
        }

        // POST api/<ProjectsController>
        [HttpPost]
        public async Task<ProjectEntity> PostAsync([FromBody] ProjectEntity project)
        {
            return await _projectService.CreateProjectAsync(project);
        }

        // PUT api/<ProjectsController>/5
        [HttpPut("{id}")]
        public async Task<ProjectEntity?> Put(int id, [FromBody] ProjectEntity project)
        {
            return await _projectService.UpdateProjectAsync(id, project);
        }

        // DELETE api/<ProjectsController>/5
        [HttpDelete("{id}")]
        public async Task DeleteAsync(int id)
        {
            await _projectService.DeleteProjectAsync(id);
        }
    }
}
