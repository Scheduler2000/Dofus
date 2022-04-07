using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class HouseToSellFilterMessage : Message
{
    public const uint Id = 3571;

    public HouseToSellFilterMessage(int areaId,
        sbyte atLeastNbRoom,
        sbyte atLeastNbChest,
        ushort skillRequested,
        ulong maxPrice,
        sbyte orderBy)
    {
        AreaId = areaId;
        AtLeastNbRoom = atLeastNbRoom;
        AtLeastNbChest = atLeastNbChest;
        SkillRequested = skillRequested;
        MaxPrice = maxPrice;
        OrderBy = orderBy;
    }

    public HouseToSellFilterMessage()
    {
    }

    public override uint MessageId => Id;

    public int AreaId { get; set; }

    public sbyte AtLeastNbRoom { get; set; }

    public sbyte AtLeastNbChest { get; set; }

    public ushort SkillRequested { get; set; }

    public ulong MaxPrice { get; set; }

    public sbyte OrderBy { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteInt(AreaId);
        writer.WriteSByte(AtLeastNbRoom);
        writer.WriteSByte(AtLeastNbChest);
        writer.WriteVarUShort(SkillRequested);
        writer.WriteVarULong(MaxPrice);
        writer.WriteSByte(OrderBy);
    }

    public override void Deserialize(IDataReader reader)
    {
        AreaId = reader.ReadInt();
        AtLeastNbRoom = reader.ReadSByte();
        AtLeastNbChest = reader.ReadSByte();
        SkillRequested = reader.ReadVarUShort();
        MaxPrice = reader.ReadVarULong();
        OrderBy = reader.ReadSByte();
    }
}