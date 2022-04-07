using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ZaapRespawnUpdatedMessage : Message
{
    public const uint Id = 2988;

    public ZaapRespawnUpdatedMessage(double mapId)
    {
        MapId = mapId;
    }

    public ZaapRespawnUpdatedMessage()
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