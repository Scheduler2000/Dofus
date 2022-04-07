using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ExchangeReadyMessage : Message
{
    public const uint Id = 5849;

    public ExchangeReadyMessage(bool ready, ushort step)
    {
        Ready = ready;
        Step = step;
    }

    public ExchangeReadyMessage()
    {
    }

    public override uint MessageId => Id;

    public bool Ready { get; set; }

    public ushort Step { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteBoolean(Ready);
        writer.WriteVarUShort(Step);
    }

    public override void Deserialize(IDataReader reader)
    {
        Ready = reader.ReadBoolean();
        Step = reader.ReadVarUShort();
    }
}