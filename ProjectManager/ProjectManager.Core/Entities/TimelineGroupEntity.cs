using System;
namespace ProjectManager.Core.Entities
{
	public class TimelineGroupEntity
	{
		public int Id { get; set; }
		public string Title { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;

		public int ProjectId { get; set; }
		public ProjectEntity Project { get; set; }

		public ICollection<TimelineItemEntity> TimelineItems { get; set; }
	}
}

