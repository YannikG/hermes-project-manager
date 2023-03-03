using System;
using ProjectManager.Core.Entities;

namespace ProjectManager.Web.Models
{
	public class TimelineItemCreateUpdateModel
	{
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public TimelineItemStatusEnum Status { get; set; }
        public TimelineItemTypeEnum Type { get; set; }
    }
}

