using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ExchangeMoneyMovementInformationMessage : Message
{
    public const uint Id = 6336;

    public ExchangeMoneyMovementInformationMessage(ulong limit)
    {
        Limit = limit;
    }

    public ExchangeMoneyMovementInformationMessage()
    {
    }

    public override uint MessageId => Id;

    public ulong Limit { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarULong(Limit);
    }

    public override void Deserialize(IDataReader reader)
    {
        Limit = reader.ReadVarULong();
    }
}