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
        private readonly TimelineGroupService _timelineGroupService;
        private readonly TimelineItemService _timelineItemService;

        public ProjectsController(ProjectService projectService, TimelineGroupService timelineGroupService, TimelineItemService timelineItemService)
        {
            _projectService = projectService;
            _timelineGroupService = timelineGroupService;
            _timelineItemService = timelineItemService;
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

        // POST api/<ProjectsController>/5/timelineGroups
        [HttpPost("{projectId}/timelineGroups")]
        public async Task<TimelineGroupEntity> TimelineGroupPostAsync([FromRoute] int projectId, [FromBody] TimelineGroupEntity timelineGroup)
        {
            timelineGroup.ProjectId = projectId;

            return await _timelineGroupService.CreateAsync(timelineGroup);
        }


        // PUT api/<ProjectsController>/5/timelineGroups/6
        [HttpPut("{projectId}/timelineGroups/{id}")]
        public async Task<TimelineGroupEntity> TimelineGroupPutAsync([FromRoute] int projectId, [FromRoute] int id, [FromBody] TimelineGroupEntity timelineGroup)
        {
            timelineGroup.ProjectId = projectId;

            return await _timelineGroupService.UpdateAsync(id, timelineGroup);
        }

        // DELETE api/<ProjectsController>/5/timelineGroups/6
        [HttpDelete("{projectId}/timelineGroups/{id}")]
        public async Task TimelineGroupDeleteAsync([FromRoute] int projectId, [FromRoute] int id)
        {
            await _timelineGroupService.DeleteAsync(id, projectId);
        }

        // POST api/<ProjectsController>/timelineGroups/6/timelineItmes
        [HttpPost("timelineGroups/{groupId}/timelineItems")]
        public async Task<TimelineItemEntity> TimelineItemPostAsync([FromRoute] int groupId, [FromBody] TimelineItemEntity timelineItemEntity)
        {
            timelineItemEntity.TimelineGroupId = groupId;

            return await _timelineItemService.CreateAsync(timelineItemEntity);
        }


        // PUT api/<ProjectsController>/timelineGroups/6/timelineItmes/7
        [HttpPut("timelineGroups/{groupId}/timelineItems/{id}")]
        public async Task<TimelineItemEntity> TimelineItemPostAsync([FromRoute] int groupId, [FromRoute] int id, [FromBody] TimelineItemEntity timelineItemEntity)
        {
            timelineItemEntity.TimelineGroupId = groupId;

            return await _timelineItemService.UpdateAsync(id, timelineItemEntity);
        }

        // DELETE api/<ProjectsController>/timelineGroups/6/timelineItmes/7
        [HttpDelete("timelineGroups/{groupId}/timelineItems/{id}")]
        public async Task TimelineItemDeleteAsync([FromRoute] int groupId, [FromRoute] int id)
        {
            await _timelineItemService.DeleteAsync(id, groupId);
        }
    }
}
