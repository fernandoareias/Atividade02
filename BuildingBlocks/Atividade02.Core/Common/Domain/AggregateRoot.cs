using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Atividade02.Core.Common.CQRS;

public abstract class AggregateRoot : Entity
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public ObjectId _id
    {
        get;
        protected set;
    } = ObjectId.GenerateNewId();

    public string AggregateId
    {
        get;
        private set;
    }


    private List<Event> _events = new List<Event>();
    public IReadOnlyCollection<Event> Events => _events;

    public void AddEvent(Event @event)
    {
        _events.Add(@event);
    }

    public void Clear() => _events.Clear();
}