using AtlasMongoWithHealthChecks.Models;

namespace AtlasMongoWithHealthChecks.Services;

public interface IStudentService
{
    Task CreateStudent(Student student);
    Task UpdateStudent(string id,Student student);
    Task DeleteStudent(string id);
    Task<Student?> GetStudent(string id);
    Task<List<Student>> GetAllStudents();
}
