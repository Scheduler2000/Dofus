using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ExchangeStartOkNpcTradeMessage : Message
{
    public const uint Id = 4055;

    public ExchangeStartOkNpcTradeMessage(double npcId)
    {
        NpcId = npcId;
    }

    public ExchangeStartOkNpcTradeMessage()
    {
    }

    public override uint MessageId => Id;

    public double NpcId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteDouble(NpcId);
    }

    public override void Deserialize(IDataReader reader)
    {
        NpcId = reader.ReadDouble();
    }
}