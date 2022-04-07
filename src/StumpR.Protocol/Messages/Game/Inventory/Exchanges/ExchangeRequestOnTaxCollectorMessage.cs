using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ExchangeRequestOnTaxCollectorMessage : Message
{
    public const uint Id = 8267;

    public override uint MessageId => Id;

    public override void Serialize(IDataWriter writer)
    {
    }

    public override void Deserialize(IDataReader reader)
    {
    }
}