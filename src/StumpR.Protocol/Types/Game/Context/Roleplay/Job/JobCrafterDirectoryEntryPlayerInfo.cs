using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class JobCrafterDirectoryEntryPlayerInfo
{
    public const short Id = 4905;

    public JobCrafterDirectoryEntryPlayerInfo(ulong playerId,
        string playerName,
        sbyte alignmentSide,
        sbyte breed,
        bool sex,
        bool isInWorkshop,
        short worldX,
        short worldY,
        double mapId,
        ushort subAreaId,
        bool canCraftLegendary,
        PlayerStatus status)
    {
        PlayerId = playerId;
        PlayerName = playerName;
        AlignmentSide = alignmentSide;
        Breed = breed;
        Sex = sex;
        IsInWorkshop = isInWorkshop;
        WorldX = worldX;
        WorldY = worldY;
        MapId = mapId;
        SubAreaId = subAreaId;
        CanCraftLegendary = canCraftLegendary;
        Status = status;
    }

    public JobCrafterDirectoryEntryPlayerInfo()
    {
    }

    public virtual short TypeId => Id;

    public ulong PlayerId { get; set; }

    public string PlayerName { get; set; }

    public sbyte AlignmentSide { get; set; }

    public sbyte Breed { get; set; }

    public bool Sex { get; set; }

    public bool IsInWorkshop { get; set; }

    public short WorldX { get; set; }

    public short WorldY { get; set; }

    public double MapId { get; set; }

    public ushort SubAreaId { get; set; }

    public bool CanCraftLegendary { get; set; }

    public PlayerStatus Status { get; set; }

    public virtual void Serialize(IDataWriter writer)
    {
        writer.WriteVarULong(PlayerId);
        writer.WriteUTF(PlayerName);
        writer.WriteSByte(AlignmentSide);
        writer.WriteSByte(Breed);
        writer.WriteBoolean(Sex);
        writer.WriteBoolean(IsInWorkshop);
        writer.WriteShort(WorldX);
        writer.WriteShort(WorldY);
        writer.WriteDouble(MapId);
        writer.WriteVarUShort(SubAreaId);
        writer.WriteBoolean(CanCraftLegendary);
        writer.WriteShort(Status.TypeId);
        Status.Serialize(writer);
    }

    public virtual void Deserialize(IDataReader reader)
    {
        PlayerId = reader.ReadVarULong();
        PlayerName = reader.ReadUTF();
        AlignmentSide = reader.ReadSByte();
        Breed = reader.ReadSByte();
        Sex = reader.ReadBoolean();
        IsInWorkshop = reader.ReadBoolean();
        WorldX = reader.ReadShort();
        WorldY = reader.ReadShort();
        MapId = reader.ReadDouble();
        SubAreaId = reader.ReadVarUShort();
        CanCraftLegendary = reader.ReadBoolean();
        Status = ProtocolTypeManager.GetInstance<PlayerStatus>(reader.ReadShort());
        Status.Deserialize(reader);
    }
}