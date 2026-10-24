using FormazioneCRM.Application.Courses;

namespace FormazioneCRM.Application.Abstractions;

public interface ICourseRepository
{
    Task<IReadOnlyList<Course>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Course?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task AddAsync(Course course, CancellationToken cancellationToken = default);
}
