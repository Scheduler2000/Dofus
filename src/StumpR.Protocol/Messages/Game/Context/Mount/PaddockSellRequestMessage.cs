using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class PaddockSellRequestMessage : Message
{
    public const uint Id = 2370;

    public PaddockSellRequestMessage(ulong price, bool forSale)
    {
        Price = price;
        ForSale = forSale;
    }

    public PaddockSellRequestMessage()
    {
    }

    public override uint MessageId => Id;

    public ulong Price { get; set; }

    public bool ForSale { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarULong(Price);
        writer.WriteBoolean(ForSale);
    }

    public override void Deserialize(IDataReader reader)
    {
        Price = reader.ReadVarULong();
        ForSale = reader.ReadBoolean();
    }
}