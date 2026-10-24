using FormazioneCRM.Application.Abstractions;
using FormazioneCRM.Application.Courses;
using Microsoft.EntityFrameworkCore;

namespace FormazioneCRM.Infrastructure.Persistence.Repositories;

public sealed class CourseRepository : ICourseRepository
{
    private readonly ApplicationDbContext _dbContext;

    public CourseRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IReadOnlyList<Course>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.Courses
            .AsNoTracking()
            .OrderBy(x => x.Title)
            .ToListAsync(cancellationToken);
    }

    public async Task<Course?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Courses
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task AddAsync(Course course, CancellationToken cancellationToken = default)
    {
        await _dbContext.Courses.AddAsync(course, cancellationToken);
    }
}
