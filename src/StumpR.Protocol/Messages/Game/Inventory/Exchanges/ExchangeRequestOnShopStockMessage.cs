using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ExchangeRequestOnShopStockMessage : Message
{
    public const uint Id = 67;

    public override uint MessageId => Id;

    public override void Serialize(IDataWriter writer)
    {
    }

    public override void Deserialize(IDataReader reader)
    {
    }
}