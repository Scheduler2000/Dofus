using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ErrorMapNotFoundMessage : Message
{
    public const uint Id = 1147;

    public ErrorMapNotFoundMessage(double mapId)
    {
        MapId = mapId;
    }

    public ErrorMapNotFoundMessage()
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