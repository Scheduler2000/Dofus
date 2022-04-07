using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class PaddockBuyRequestMessage : Message
{
    public const uint Id = 8638;

    public PaddockBuyRequestMessage(ulong proposedPrice)
    {
        ProposedPrice = proposedPrice;
    }

    public PaddockBuyRequestMessage()
    {
    }

    public override uint MessageId => Id;

    public ulong ProposedPrice { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarULong(ProposedPrice);
    }

    public override void Deserialize(IDataReader reader)
    {
        ProposedPrice = reader.ReadVarULong();
    }
}