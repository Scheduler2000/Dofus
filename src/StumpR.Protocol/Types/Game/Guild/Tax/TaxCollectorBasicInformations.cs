using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class TaxCollectorBasicInformations
{
    public const short Id = 1488;

    public TaxCollectorBasicInformations(ushort firstNameId,
        ushort lastNameId,
        short worldX,
        short worldY,
        double mapId,
        ushort subAreaId)
    {
        FirstNameId = firstNameId;
        LastNameId = lastNameId;
        WorldX = worldX;
        WorldY = worldY;
        MapId = mapId;
        SubAreaId = subAreaId;
    }

    public TaxCollectorBasicInformations()
    {
    }

    public virtual short TypeId => Id;

    public ushort FirstNameId { get; set; }

    public ushort LastNameId { get; set; }

    public short WorldX { get; set; }

    public short WorldY { get; set; }

    public double MapId { get; set; }

    public ushort SubAreaId { get; set; }

    public virtual void Serialize(IDataWriter writer)
    {
        writer.WriteVarUShort(FirstNameId);
        writer.WriteVarUShort(LastNameId);
        writer.WriteShort(WorldX);
        writer.WriteShort(WorldY);
        writer.WriteDouble(MapId);
        writer.WriteVarUShort(SubAreaId);
    }

    public virtual void Deserialize(IDataReader reader)
    {
        FirstNameId = reader.ReadVarUShort();
        LastNameId = reader.ReadVarUShort();
        WorldX = reader.ReadShort();
        WorldY = reader.ReadShort();
        MapId = reader.ReadDouble();
        SubAreaId = reader.ReadVarUShort();
    }
}