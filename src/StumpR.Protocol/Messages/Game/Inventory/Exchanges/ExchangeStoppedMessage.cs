using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ExchangeStoppedMessage : Message
{
    public const uint Id = 8743;

    public ExchangeStoppedMessage(ulong objectId)
    {
        ObjectId = objectId;
    }

    public ExchangeStoppedMessage()
    {
    }

    public override uint MessageId => Id;

    public ulong ObjectId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarULong(ObjectId);
    }

    public override void Deserialize(IDataReader reader)
    {
        ObjectId = reader.ReadVarULong();
    }
}