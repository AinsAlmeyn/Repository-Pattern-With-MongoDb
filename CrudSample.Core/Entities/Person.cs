using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace CrudSample.Core.Entities
{
    public class Person : BaseEntity
    {
        [BsonElement(nameof(Name))] public string Name { get; set; }
        [BsonElement(nameof(Surname))] public string Surname { get; set;}
        [BsonElement(nameof(Age))] public int Age { get; set; }
        [BsonElement(nameof(Gender))] public string Gender { get; set; }
    }
}
