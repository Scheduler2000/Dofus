using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class PurchasableDialogMessage : Message
{
    public const uint Id = 582;

    public PurchasableDialogMessage(bool buyOrSell, bool secondHand, double purchasableId, int purchasableInstanceId, ulong price)
    {
        BuyOrSell = buyOrSell;
        SecondHand = secondHand;
        PurchasableId = purchasableId;
        PurchasableInstanceId = purchasableInstanceId;
        Price = price;
    }

    public PurchasableDialogMessage()
    {
    }

    public override uint MessageId => Id;

    public bool BuyOrSell { get; set; }

    public bool SecondHand { get; set; }

    public double PurchasableId { get; set; }

    public int PurchasableInstanceId { get; set; }

    public ulong Price { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        var flag = new byte();
        flag = BooleanByteWrapper.SetFlag(flag, 0, BuyOrSell);
        flag = BooleanByteWrapper.SetFlag(flag, 1, SecondHand);
        writer.WriteByte(flag);
        writer.WriteDouble(PurchasableId);
        writer.WriteInt(PurchasableInstanceId);
        writer.WriteVarULong(Price);
    }

    public override void Deserialize(IDataReader reader)
    {
        byte flag = reader.ReadByte();
        BuyOrSell = BooleanByteWrapper.GetFlag(flag, 0);
        SecondHand = BooleanByteWrapper.GetFlag(flag, 1);
        PurchasableId = reader.ReadDouble();
        PurchasableInstanceId = reader.ReadInt();
        Price = reader.ReadVarULong();
    }
}