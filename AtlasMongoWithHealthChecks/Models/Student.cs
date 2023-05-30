using MongoDB.Bson.Serialization.Attributes;
using System.Collections.ObjectModel;

namespace AtlasMongoWithHealthChecks.Models;

public class Student
{
    [BsonId]
    [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
    public string? Id { get; set; }
    [BsonElement("id")]
    public decimal Student_Id { get; set; }
    public Collection<Score> Scores { get; set; } = new Collection<Score>();
    public decimal Class_Id { get; set; }
}
