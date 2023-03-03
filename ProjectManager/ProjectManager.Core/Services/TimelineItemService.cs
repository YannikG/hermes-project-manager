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
    public class TimelineItemService
    {
        private readonly ProjectContext _projectContext;

        public TimelineItemService(ProjectContext projectContext)
        {
            _projectContext = projectContext;
        }

        public async Task<TimelineItemEntity> CreateAsync(TimelineItemEntity timelineItemEntity)
        {
            if (timelineItemEntity is null)
                throw new ArgumentNullException(nameof(timelineItemEntity));

            timelineItemEntity.Id = default;

            await _projectContext.AddAsync(timelineItemEntity);
            await _projectContext.SaveChangesAsync();

            return timelineItemEntity;
        }

        public async Task<TimelineItemEntity> UpdateAsync(int id, TimelineItemEntity timelineItemEntity)
        {
            if (timelineItemEntity is null)
                throw new ArgumentNullException(nameof(timelineItemEntity));

            var timelineItemEntityFromDB = await _projectContext.TimelineItems.FirstOrDefaultAsync(tli => tli.Id == id);

            if (timelineItemEntityFromDB is null)
                return null;

            timelineItemEntityFromDB.Description = timelineItemEntity.Description;
            timelineItemEntityFromDB.Title = timelineItemEntity.Title;
            timelineItemEntityFromDB.EndDateTime = timelineItemEntity.EndDateTime;
            timelineItemEntityFromDB.StartDateTime = timelineItemEntity.StartDateTime;
            timelineItemEntityFromDB.Status = timelineItemEntity.Status;
            timelineItemEntityFromDB.Type = timelineItemEntity.Type;

            await _projectContext.SaveChangesAsync();

            return timelineItemEntityFromDB;
        }

        public async Task DeleteAsync(int id, int groupId)
        {
            var timelineItemEntity = new TimelineItemEntity() { Id = id, TimelineGroupId = groupId };

            _projectContext.Attach(timelineItemEntity);
            _projectContext.Remove(timelineItemEntity);

            await _projectContext.SaveChangesAsync();
        }
    }
}
