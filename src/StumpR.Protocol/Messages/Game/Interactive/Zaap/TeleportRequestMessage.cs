using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class TeleportRequestMessage : Message
{
    public const uint Id = 1539;

    public TeleportRequestMessage(sbyte sourceType, sbyte destinationType, double mapId)
    {
        SourceType = sourceType;
        DestinationType = destinationType;
        MapId = mapId;
    }

    public TeleportRequestMessage()
    {
    }

    public override uint MessageId => Id;

    public sbyte SourceType { get; set; }

    public sbyte DestinationType { get; set; }

    public double MapId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteSByte(SourceType);
        writer.WriteSByte(DestinationType);
        writer.WriteDouble(MapId);
    }

    public override void Deserialize(IDataReader reader)
    {
        SourceType = reader.ReadSByte();
        DestinationType = reader.ReadSByte();
        MapId = reader.ReadDouble();
    }
}