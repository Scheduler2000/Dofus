using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ExchangeCraftCountRequestMessage : Message
{
    public const uint Id = 7316;

    public ExchangeCraftCountRequestMessage(int count)
    {
        Count = count;
    }

    public ExchangeCraftCountRequestMessage()
    {
    }

    public override uint MessageId => Id;

    public int Count { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarInt(Count);
    }

    public override void Deserialize(IDataReader reader)
    {
        Count = reader.ReadVarInt();
    }
}