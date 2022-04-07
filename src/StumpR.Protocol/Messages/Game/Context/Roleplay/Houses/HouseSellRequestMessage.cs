using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class HouseSellRequestMessage : Message
{
    public const uint Id = 9330;

    public HouseSellRequestMessage(int instanceId, ulong amount, bool forSale)
    {
        InstanceId = instanceId;
        Amount = amount;
        ForSale = forSale;
    }

    public HouseSellRequestMessage()
    {
    }

    public override uint MessageId => Id;

    public int InstanceId { get; set; }

    public ulong Amount { get; set; }

    public bool ForSale { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteInt(InstanceId);
        writer.WriteVarULong(Amount);
        writer.WriteBoolean(ForSale);
    }

    public override void Deserialize(IDataReader reader)
    {
        InstanceId = reader.ReadInt();
        Amount = reader.ReadVarULong();
        ForSale = reader.ReadBoolean();
    }
}