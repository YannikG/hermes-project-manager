using Microsoft.AspNetCore.Mvc;
using ProjectManager.Core.Entities;
using ProjectManager.Core.Services;
using ProjectManager.Web.Models;

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
        public async Task<ProjectEntity> PostAsync([FromBody] ProjectCreateUpdateModel model)
        {
            var projectEntity = new ProjectEntity()
            {
                ConfigWorkHoursPerDay = model.ConfigWorkHoursPerDay,
                ConfigWorkHoursPerWeek = model.ConfigWorkHoursPerWeek,
                Description = model.Description,
                ProjectEndDate = model.ProjectEndDate,
                ProjectStartDate = model.ProjectStartDate,
                Title = model.Title
            };

            return await _projectService.CreateProjectAsync(projectEntity);
        }

        // PUT api/<ProjectsController>/5
        [HttpPut("{id}")]
        public async Task<ProjectEntity?> Put(int id, [FromBody] ProjectCreateUpdateModel model)
        {
            var projectEntity = new ProjectEntity()
            {
                ConfigWorkHoursPerDay = model.ConfigWorkHoursPerDay,
                ConfigWorkHoursPerWeek = model.ConfigWorkHoursPerWeek,
                Description = model.Description,
                ProjectEndDate = model.ProjectEndDate,
                ProjectStartDate = model.ProjectStartDate,
                Title = model.Title
            };

            return await _projectService.UpdateProjectAsync(id, projectEntity);
        }

        // DELETE api/<ProjectsController>/5
        [HttpDelete("{id}")]
        public async Task DeleteAsync(int id)
        {
            await _projectService.DeleteProjectAsync(id);
        }

        // POST api/<ProjectsController>/5/timelineGroups
        [HttpPost("{projectId}/timelineGroups")]
        public async Task<TimelineGroupEntity> TimelineGroupPostAsync([FromRoute] int projectId, [FromBody] TimelineGroupCreateUpdateModel model)
        {
            var timelineGroupEntity = new TimelineGroupEntity()
            {
                Description = model.Description,
                ProjectId = projectId,
                Title = model.Title
            };

            return await _timelineGroupService.CreateAsync(timelineGroupEntity);
        }


        // PUT api/<ProjectsController>/5/timelineGroups/6
        [HttpPut("{projectId}/timelineGroups/{id}")]
        public async Task<TimelineGroupEntity> TimelineGroupPutAsync([FromRoute] int projectId, [FromRoute] int id, [FromBody] TimelineGroupCreateUpdateModel model)
        {
            var timelineGroupEntity = new TimelineGroupEntity()
            {
                Description = model.Description,
                ProjectId = projectId,
                Title = model.Title
            };

            return await _timelineGroupService.UpdateAsync(id, timelineGroupEntity);
        }

        // DELETE api/<ProjectsController>/5/timelineGroups/6
        [HttpDelete("{projectId}/timelineGroups/{id}")]
        public async Task TimelineGroupDeleteAsync([FromRoute] int projectId, [FromRoute] int id)
        {
            await _timelineGroupService.DeleteAsync(id, projectId);
        }

        // POST api/<ProjectsController>/timelineGroups/6/timelineItmes
        [HttpPost("timelineGroups/{groupId}/timelineItems")]
        public async Task<TimelineItemEntity> TimelineItemPostAsync([FromRoute] int groupId, [FromBody] TimelineItemCreateUpdateModel model)
        {
            var timelineItemEntity = new TimelineItemEntity()
            {
                Title = model.Title,
                Description = model.Description,
                EndDateTime = model.EndDateTime,
                StartDateTime = model.StartDateTime,
                Status = model.Status,
                TimelineGroupId = groupId,
                Type = model.Type
            };

            return await _timelineItemService.CreateAsync(timelineItemEntity);
        }


        // PUT api/<ProjectsController>/timelineGroups/6/timelineItmes/7
        [HttpPut("timelineGroups/{groupId}/timelineItems/{id}")]
        public async Task<TimelineItemEntity> TimelineItemPostAsync([FromRoute] int groupId, [FromRoute] int id, [FromBody] TimelineItemCreateUpdateModel model)
        {
            var timelineItemEntity = new TimelineItemEntity()
            {
                Title = model.Title,
                Description = model.Description,
                EndDateTime = model.EndDateTime,
                StartDateTime = model.StartDateTime,
                Status = model.Status,
                TimelineGroupId = groupId,
                Type = model.Type
            };
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
