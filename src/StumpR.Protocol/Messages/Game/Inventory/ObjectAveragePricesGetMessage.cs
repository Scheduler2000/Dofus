using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ObjectAveragePricesGetMessage : Message
{
    public const uint Id = 1653;

    public override uint MessageId => Id;

    public override void Serialize(IDataWriter writer)
    {
    }

    public override void Deserialize(IDataReader reader)
    {
    }
}