using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GameContextReadyMessage : Message
{
    public const uint Id = 912;

    public GameContextReadyMessage(double mapId)
    {
        MapId = mapId;
    }

    public GameContextReadyMessage()
    {
    }

    public override uint MessageId => Id;

    public double MapId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteDouble(MapId);
    }

    public override void Deserialize(IDataReader reader)
    {
        MapId = reader.ReadDouble();
    }
}