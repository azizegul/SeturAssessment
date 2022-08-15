using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PhoneBook.Report.Domain.Common;

public abstract class BaseEntity
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public bool IsDeleted { get; set; } = false;
}