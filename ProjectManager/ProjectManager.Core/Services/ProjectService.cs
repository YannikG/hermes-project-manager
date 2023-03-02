using Microsoft.EntityFrameworkCore;
using ProjectManager.Core.DataAccess;
using ProjectManager.Core.Entities;

namespace ProjectManager.Core.Services
{
    public class ProjectService
    {
        private readonly ProjectContext _context;

        public ProjectService(ProjectContext context)
        {
            _context = context;
        }

        public async Task<ProjectEntity?> GetProjectByIdAsync(int id)
        {
            return await _context.Projects
                .Include(p => p.TimelineGroups)
                .ThenInclude(tlg => tlg.TimelineItems)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<ProjectEntity>> GetProjectsAsync()
        {
            return await _context.Projects
                .Include(p => p.TimelineGroups)
                .ThenInclude(tlg => tlg.TimelineItems)
                .ToListAsync();
        }

        public async Task<ProjectEntity> CreateProjectAsync(ProjectEntity project)
        {
            if (project is null)
                throw new ArgumentNullException(nameof(project));

            project.Id = default;

            await _context.Projects.AddAsync(project);
            await _context.SaveChangesAsync();

            return project;
        }

        public async Task<ProjectEntity> UpdateProjectAsync(int id, ProjectEntity project)
        {
            if (project is null)
                throw new ArgumentNullException(nameof(project));

            var projectFromDatabase = await _context.Projects
                .Include(p => p.TimelineGroups)
                .ThenInclude(tlg => tlg.TimelineItems)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (projectFromDatabase is null)
                return null;

            projectFromDatabase.Title = project.Title;
            projectFromDatabase.Description = project.Description;
            projectFromDatabase.ProjectStartDate = project.ProjectStartDate;
            projectFromDatabase.ProjectEndDate = project.ProjectEndDate;
            projectFromDatabase.ConfigWorkHoursPerDay = project.ConfigWorkHoursPerDay;
            projectFromDatabase.ConfigWorkHoursPerWeek = project.ConfigWorkHoursPerWeek;

            await _context.SaveChangesAsync();

            return projectFromDatabase;
        }

        public async Task DeleteProjectAsync(int id)
        {
            ProjectEntity project = new ProjectEntity() { Id = id };
            _context.Attach(project);
            _context.Remove(project);
            await _context.SaveChangesAsync();
        }
    }
}
