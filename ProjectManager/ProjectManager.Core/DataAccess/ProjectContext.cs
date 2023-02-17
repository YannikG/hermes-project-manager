using System;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Core.Entities;

namespace ProjectManager.Core.DataAccess
{
	public class ProjectContext : DbContext
	{
		public ProjectContext(DbContextOptions<ProjectContext> options) : base(options) { }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// ProjectEntity
			modelBuilder.Entity<ProjectEntity>()
				.HasKey(p => p.Id);

            // TimelineGroupEntity
            modelBuilder.Entity<TimelineGroupEntity>()
				.HasKey(tlg => tlg.Id);
			modelBuilder.Entity<TimelineGroupEntity>()
				.HasOne<ProjectEntity>(tlg => tlg.Project)
				.WithMany(p => p.TimelineGroups)
				.HasForeignKey(tlg => tlg.ProjectId);

			// TimelineItemEntity
			modelBuilder.Entity<TimelineItemEntity>()
				.HasKey(tli => tli.Id);
			modelBuilder.Entity<TimelineItemEntity>()
				.HasOne<TimelineGroupEntity>(tli => tli.TimelineGroup)
				.WithMany(tlg => tlg.TimelineItems)
				.HasForeignKey(tli => tli.TimelineGroupId);
        }

        public DbSet<ProjectEntity> Projects { get; set; }
		public DbSet<TimelineGroupEntity> TimelineGroups { get; set; }
		public DbSet<TimelineItemEntity> TimelineItems { get; set; }
	}
}

