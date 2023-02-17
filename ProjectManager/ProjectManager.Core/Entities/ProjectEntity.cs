using System;
namespace ProjectManager.Core.Entities
{
	public class ProjectEntity
	{
		public int Id { get; set; }
		public string Title { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public int ConfigWorkHoursPerDay { get; set; }
		public int ConfigWorkHoursPerWeek { get; set; }
		public DateTime ProjectStartDate { get; set; }
		public DateTime ProjectEndDate { get; set; }

		public ICollection<TimelineGroupEntity> TimelineGroups { get; set; }
	}
}

