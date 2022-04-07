using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class HouseSellingUpdateMessage : Message
{
    public const uint Id = 3951;

    public HouseSellingUpdateMessage(uint houseId, int instanceId, bool secondHand, ulong realPrice, AccountTagInformation buyerTag)
    {
        HouseId = houseId;
        InstanceId = instanceId;
        SecondHand = secondHand;
        RealPrice = realPrice;
        BuyerTag = buyerTag;
    }

    public HouseSellingUpdateMessage()
    {
    }

    public override uint MessageId => Id;

    public uint HouseId { get; set; }

    public int InstanceId { get; set; }

    public bool SecondHand { get; set; }

    public ulong RealPrice { get; set; }

    public AccountTagInformation BuyerTag { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarUInt(HouseId);
        writer.WriteInt(InstanceId);
        writer.WriteBoolean(SecondHand);
        writer.WriteVarULong(RealPrice);
        BuyerTag.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        HouseId = reader.ReadVarUInt();
        InstanceId = reader.ReadInt();
        SecondHand = reader.ReadBoolean();
        RealPrice = reader.ReadVarULong();
        BuyerTag = new AccountTagInformation();
        BuyerTag.Deserialize(reader);
    }
}