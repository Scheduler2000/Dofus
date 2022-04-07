using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class PartyMemberGeoPosition
{
    public const short Id = 6723;

    public PartyMemberGeoPosition(int memberId, short worldX, short worldY, double mapId, ushort subAreaId)
    {
        MemberId = memberId;
        WorldX = worldX;
        WorldY = worldY;
        MapId = mapId;
        SubAreaId = subAreaId;
    }

    public PartyMemberGeoPosition()
    {
    }

    public virtual short TypeId => Id;

    public int MemberId { get; set; }

    public short WorldX { get; set; }

    public short WorldY { get; set; }

    public double MapId { get; set; }

    public ushort SubAreaId { get; set; }

    public virtual void Serialize(IDataWriter writer)
    {
        writer.WriteInt(MemberId);
        writer.WriteShort(WorldX);
        writer.WriteShort(WorldY);
        writer.WriteDouble(MapId);
        writer.WriteVarUShort(SubAreaId);
    }

    public virtual void Deserialize(IDataReader reader)
    {
        MemberId = reader.ReadInt();
        WorldX = reader.ReadShort();
        WorldY = reader.ReadShort();
        MapId = reader.ReadDouble();
        SubAreaId = reader.ReadVarUShort();
    }
}