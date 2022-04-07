using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class HouseSellFromInsideRequestMessage : HouseSellRequestMessage
{
    public new const uint Id = 5075;

    public HouseSellFromInsideRequestMessage(int instanceId, ulong amount, bool forSale)
    {
        InstanceId = instanceId;
        Amount = amount;
        ForSale = forSale;
    }

    public HouseSellFromInsideRequestMessage()
    {
    }

    public override uint MessageId => Id;

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
    }
}