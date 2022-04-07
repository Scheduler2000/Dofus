using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class HouseBuyResultMessage : Message
{
    public const uint Id = 9533;

    public HouseBuyResultMessage(bool secondHand, bool bought, uint houseId, int instanceId, ulong realPrice)
    {
        SecondHand = secondHand;
        Bought = bought;
        HouseId = houseId;
        InstanceId = instanceId;
        RealPrice = realPrice;
    }

    public HouseBuyResultMessage()
    {
    }

    public override uint MessageId => Id;

    public bool SecondHand { get; set; }

    public bool Bought { get; set; }

    public uint HouseId { get; set; }

    public int InstanceId { get; set; }

    public ulong RealPrice { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        var flag = new byte();
        flag = BooleanByteWrapper.SetFlag(flag, 0, SecondHand);
        flag = BooleanByteWrapper.SetFlag(flag, 1, Bought);
        writer.WriteByte(flag);
        writer.WriteVarUInt(HouseId);
        writer.WriteInt(InstanceId);
        writer.WriteVarULong(RealPrice);
    }

    public override void Deserialize(IDataReader reader)
    {
        byte flag = reader.ReadByte();
        SecondHand = BooleanByteWrapper.GetFlag(flag, 0);
        Bought = BooleanByteWrapper.GetFlag(flag, 1);
        HouseId = reader.ReadVarUInt();
        InstanceId = reader.ReadInt();
        RealPrice = reader.ReadVarULong();
    }
}