using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class MapInformationsRequestMessage : Message
{
    public const uint Id = 2396;

    public MapInformationsRequestMessage(double mapId)
    {
        MapId = mapId;
    }

    public MapInformationsRequestMessage()
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