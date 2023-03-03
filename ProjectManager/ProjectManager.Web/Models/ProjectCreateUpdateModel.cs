using System;
namespace ProjectManager.Web.Models
{
	public class ProjectCreateUpdateModel
	{
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int ConfigWorkHoursPerDay { get; set; }
        public int ConfigWorkHoursPerWeek { get; set; }
        public DateTime ProjectStartDate { get; set; }
        public DateTime ProjectEndDate { get; set; }
    }
}

