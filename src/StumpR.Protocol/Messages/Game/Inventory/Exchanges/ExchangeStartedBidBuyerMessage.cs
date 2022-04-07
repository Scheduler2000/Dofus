using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ExchangeStartedBidBuyerMessage : Message
{
    public const uint Id = 9037;

    public ExchangeStartedBidBuyerMessage(SellerBuyerDescriptor buyerDescriptor)
    {
        BuyerDescriptor = buyerDescriptor;
    }

    public ExchangeStartedBidBuyerMessage()
    {
    }

    public override uint MessageId => Id;

    public SellerBuyerDescriptor BuyerDescriptor { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        BuyerDescriptor.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        BuyerDescriptor = new SellerBuyerDescriptor();
        BuyerDescriptor.Deserialize(reader);
    }
}