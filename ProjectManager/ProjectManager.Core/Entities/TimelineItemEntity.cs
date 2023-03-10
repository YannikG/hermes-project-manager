using System;
namespace ProjectManager.Core.Entities
{
	public class TimelineItemEntity
	{
		public int Id { get; set; }
		public string Title { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public DateTime StartDateTime { get; set; }
		public DateTime EndDateTime { get; set; }
		public TimelineItemStatusEnum Status { get; set; }
		public TimelineItemTypeEnum Type { get; set; }
        public int SortRank { get; set; }
        public int TimelineGroupId { get; set; }
		public TimelineGroupEntity TimelineGroup { get; set; }
	}
}

