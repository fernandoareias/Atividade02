using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Atividade02.Core.Common.CQRS;

public abstract class Entity
{


  

    [BsonElement("CreatedAt")]
    public DateTime CreatedAt
    {
        get;
        protected set;
    } = DateTime.UtcNow;

    [BsonElement("UpdatedAt")]
    public DateTime? UpdatedAt
    {
        get;
        protected set;
    }
}