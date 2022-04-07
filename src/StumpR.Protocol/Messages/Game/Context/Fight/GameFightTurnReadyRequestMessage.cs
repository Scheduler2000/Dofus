using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GameFightTurnReadyRequestMessage : Message
{
    public const uint Id = 4389;

    public GameFightTurnReadyRequestMessage(double objectId)
    {
        ObjectId = objectId;
    }

    public GameFightTurnReadyRequestMessage()
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