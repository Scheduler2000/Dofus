using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ExchangeWaitingResultMessage : Message
{
    public const uint Id = 4369;

    public ExchangeWaitingResultMessage(bool bwait)
    {
        Bwait = bwait;
    }

    public ExchangeWaitingResultMessage()
    {
    }

    public override uint MessageId => Id;

    public bool Bwait { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteBoolean(Bwait);
    }

    public override void Deserialize(IDataReader reader)
    {
        Bwait = reader.ReadBoolean();
    }
}