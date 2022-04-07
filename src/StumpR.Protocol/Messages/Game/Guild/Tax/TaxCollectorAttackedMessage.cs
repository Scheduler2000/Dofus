using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class TaxCollectorAttackedMessage : Message
{
    public const uint Id = 4728;

    public TaxCollectorAttackedMessage(ushort firstNameId,
        ushort lastNameId,
        short worldX,
        short worldY,
        double mapId,
        ushort subAreaId,
        BasicGuildInformations guild)
    {
        FirstNameId = firstNameId;
        LastNameId = lastNameId;
        WorldX = worldX;
        WorldY = worldY;
        MapId = mapId;
        SubAreaId = subAreaId;
        Guild = guild;
    }

    public TaxCollectorAttackedMessage()
    {
    }

    public override uint MessageId => Id;

    public ushort FirstNameId { get; set; }

    public ushort LastNameId { get; set; }

    public short WorldX { get; set; }

    public short WorldY { get; set; }

    public double MapId { get; set; }

    public ushort SubAreaId { get; set; }

    public BasicGuildInformations Guild { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarUShort(FirstNameId);
        writer.WriteVarUShort(LastNameId);
        writer.WriteShort(WorldX);
        writer.WriteShort(WorldY);
        writer.WriteDouble(MapId);
        writer.WriteVarUShort(SubAreaId);
        Guild.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        FirstNameId = reader.ReadVarUShort();
        LastNameId = reader.ReadVarUShort();
        WorldX = reader.ReadShort();
        WorldY = reader.ReadShort();
        MapId = reader.ReadDouble();
        SubAreaId = reader.ReadVarUShort();
        Guild = new BasicGuildInformations();
        Guild.Deserialize(reader);
    }
}