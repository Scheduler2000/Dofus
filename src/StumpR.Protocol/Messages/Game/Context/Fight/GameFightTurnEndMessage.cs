using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GameFightTurnEndMessage : Message
{
    public const uint Id = 4443;

    public GameFightTurnEndMessage(double objectId)
    {
        ObjectId = objectId;
    }

    public GameFightTurnEndMessage()
    {
    }

    public override uint MessageId => Id;

    public double ObjectId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteDouble(ObjectId);
    }

    public override void Deserialize(IDataReader reader)
    {
        ObjectId = reader.ReadDouble();
    }
}