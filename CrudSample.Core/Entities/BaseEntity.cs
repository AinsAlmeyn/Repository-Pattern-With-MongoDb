using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace CrudSample.Core.Entities
{
    public class BaseEntity
    {
        [BsonId] public ObjectId Id { get; set; }
    }
}
