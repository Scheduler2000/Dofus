using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class PaddockSellBuyDialogMessage : Message
{
    public const uint Id = 7880;

    public PaddockSellBuyDialogMessage(bool bsell, uint ownerId, ulong price)
    {
        Bsell = bsell;
        OwnerId = ownerId;
        Price = price;
    }

    public PaddockSellBuyDialogMessage()
    {
    }

    public override uint MessageId => Id;

    public bool Bsell { get; set; }

    public uint OwnerId { get; set; }

    public ulong Price { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteBoolean(Bsell);
        writer.WriteVarUInt(OwnerId);
        writer.WriteVarULong(Price);
    }

    public override void Deserialize(IDataReader reader)
    {
        Bsell = reader.ReadBoolean();
        OwnerId = reader.ReadVarUInt();
        Price = reader.ReadVarULong();
    }
}