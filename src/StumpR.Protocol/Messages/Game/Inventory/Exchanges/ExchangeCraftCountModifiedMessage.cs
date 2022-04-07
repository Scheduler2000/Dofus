using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ExchangeCraftCountModifiedMessage : Message
{
    public const uint Id = 2567;

    public ExchangeCraftCountModifiedMessage(int count)
    {
        Count = count;
    }

    public ExchangeCraftCountModifiedMessage()
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