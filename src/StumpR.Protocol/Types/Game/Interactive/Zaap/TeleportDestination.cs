using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class TeleportDestination
{
    public const short Id = 9066;

    public TeleportDestination(sbyte type, double mapId, ushort subAreaId, ushort level, ushort cost)
    {
        Type = type;
        MapId = mapId;
        SubAreaId = subAreaId;
        Level = level;
        Cost = cost;
    }

    public TeleportDestination()
    {
    }

    public virtual short TypeId => Id;

    public sbyte Type { get; set; }

    public double MapId { get; set; }

    public ushort SubAreaId { get; set; }

    public ushort Level { get; set; }

    public ushort Cost { get; set; }

    public virtual void Serialize(IDataWriter writer)
    {
        writer.WriteSByte(Type);
        writer.WriteDouble(MapId);
        writer.WriteVarUShort(SubAreaId);
        writer.WriteVarUShort(Level);
        writer.WriteVarUShort(Cost);
    }

    public virtual void Deserialize(IDataReader reader)
    {
        Type = reader.ReadSByte();
        MapId = reader.ReadDouble();
        SubAreaId = reader.ReadVarUShort();
        Level = reader.ReadVarUShort();
        Cost = reader.ReadVarUShort();
    }
}