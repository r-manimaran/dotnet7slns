using AtlasMongoWithHealthChecks.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace AtlasMongoWithHealthChecks.Services;

public class StudentService : IStudentService
{
    private readonly IMongoCollection<Student> _students;
    public StudentService(IOptions<DatabaseSettings> databaseSettings)
    {
        var mongoClient = new MongoClient(databaseSettings.Value.ConnectionString);
        var mongoDb = mongoClient.GetDatabase(databaseSettings.Value.DatabaseName);
        _students = mongoDb.GetCollection<Student>(databaseSettings.Value.CollectionName);
    }

    public async Task CreateStudent(Student student)
    {
        await _students.InsertOneAsync(student);
    }

    public async Task DeleteStudent(string id)
    {
        await _students.DeleteOneAsync(x => x.Id == id);
    }

    public async Task<List<Student>> GetAllStudents()
    {
        var students = await _students.Find(_ => true).ToListAsync();
        return students;
    }

    public async Task<Student?> GetStudent(string id)
    {
        return await _students.Find(x => x.Id == id).FirstOrDefaultAsync();
    }

    public async Task UpdateStudent(string id, Student student)
    {
        await _students.ReplaceOneAsync(x => x.Id == id, student);
    }
}
