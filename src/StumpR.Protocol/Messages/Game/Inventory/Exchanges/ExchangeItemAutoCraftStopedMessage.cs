using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ExchangeItemAutoCraftStopedMessage : Message
{
    public const uint Id = 470;

    public ExchangeItemAutoCraftStopedMessage(sbyte reason)
    {
        Reason = reason;
    }

    public ExchangeItemAutoCraftStopedMessage()
    {
    }

    public override uint MessageId => Id;

    public sbyte Reason { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteSByte(Reason);
    }

    public override void Deserialize(IDataReader reader)
    {
        Reason = reader.ReadSByte();
    }
}