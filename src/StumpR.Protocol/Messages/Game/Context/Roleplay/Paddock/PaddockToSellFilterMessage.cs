using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class PaddockToSellFilterMessage : Message
{
    public const uint Id = 8388;

    public PaddockToSellFilterMessage(int areaId, sbyte atLeastNbMount, sbyte atLeastNbMachine, ulong maxPrice, sbyte orderBy)
    {
        AreaId = areaId;
        AtLeastNbMount = atLeastNbMount;
        AtLeastNbMachine = atLeastNbMachine;
        MaxPrice = maxPrice;
        OrderBy = orderBy;
    }

    public PaddockToSellFilterMessage()
    {
    }

    public override uint MessageId => Id;

    public int AreaId { get; set; }

    public sbyte AtLeastNbMount { get; set; }

    public sbyte AtLeastNbMachine { get; set; }

    public ulong MaxPrice { get; set; }

    public sbyte OrderBy { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteInt(AreaId);
        writer.WriteSByte(AtLeastNbMount);
        writer.WriteSByte(AtLeastNbMachine);
        writer.WriteVarULong(MaxPrice);
        writer.WriteSByte(OrderBy);
    }

    public override void Deserialize(IDataReader reader)
    {
        AreaId = reader.ReadInt();
        AtLeastNbMount = reader.ReadSByte();
        AtLeastNbMachine = reader.ReadSByte();
        MaxPrice = reader.ReadVarULong();
        OrderBy = reader.ReadSByte();
    }
}