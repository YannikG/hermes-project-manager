using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Core.DataAccess;
using ProjectManager.Core.Entities;

namespace ProjectManager.Core.Services
{
    public class TimelineGroupService
    {
        private readonly ProjectContext _projectContext;

        public TimelineGroupService(ProjectContext projectContext)
        {
            _projectContext = projectContext;
        }

        public async Task<TimelineGroupEntity> CreateAsync(TimelineGroupEntity timelineGroupEntity)
        {
            if (timelineGroupEntity is null)
                throw new ArgumentNullException(nameof(timelineGroupEntity));

            timelineGroupEntity.Id = default;

            await _projectContext.TimelineGroups.AddAsync(timelineGroupEntity);

            await _projectContext.SaveChangesAsync();

            return timelineGroupEntity;
        }

        public async Task<TimelineGroupEntity> UpdateAsync(int id, TimelineGroupEntity timelineGroupEntity)
        {
            if (id == default)
                throw new ArgumentException("cannot be default", nameof(id));

            if (timelineGroupEntity is null)
                throw new ArgumentNullException(nameof(timelineGroupEntity));

            var timeLineGroupEntityFromDB = await _projectContext.TimelineGroups.FirstOrDefaultAsync(tlg => tlg.Id == id);

            if (timeLineGroupEntityFromDB is null)
                return null;

            timeLineGroupEntityFromDB.ProjectId = timelineGroupEntity.ProjectId;
            timeLineGroupEntityFromDB.Title = timelineGroupEntity.Title;
            timeLineGroupEntityFromDB.Description = timeLineGroupEntityFromDB.Description;

            await _projectContext.SaveChangesAsync();

            return timeLineGroupEntityFromDB;
        }

        public async Task DeleteAsync(int id, int projectId)
        {
            var timeLineGroupEntity = new TimelineGroupEntity() { Id = id, ProjectId = projectId };

            _projectContext.Attach(timeLineGroupEntity);
            _projectContext.Remove(timeLineGroupEntity);

            await _projectContext.SaveChangesAsync();
        }
    }
}
