using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GameContextRemoveElementMessage : Message
{
    public const uint Id = 5284;

    public GameContextRemoveElementMessage(double objectId)
    {
        ObjectId = objectId;
    }

    public GameContextRemoveElementMessage()
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