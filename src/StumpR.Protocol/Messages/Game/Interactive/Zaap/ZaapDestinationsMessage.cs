using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ZaapDestinationsMessage : TeleportDestinationsMessage
{
    public new const uint Id = 4167;

    public ZaapDestinationsMessage(sbyte type, IEnumerable<TeleportDestination> destinations, double spawnMapId)
    {
        Type = type;
        Destinations = destinations;
        SpawnMapId = spawnMapId;
    }

    public ZaapDestinationsMessage()
    {
    }

    public override uint MessageId => Id;

    public double SpawnMapId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteDouble(SpawnMapId);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        SpawnMapId = reader.ReadDouble();
    }
}