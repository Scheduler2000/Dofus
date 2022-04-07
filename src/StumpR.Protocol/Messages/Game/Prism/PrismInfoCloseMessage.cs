using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class PrismInfoCloseMessage : Message
{
    public const uint Id = 2031;

    public override uint MessageId => Id;

    public override void Serialize(IDataWriter writer)
    {
    }

    public override void Deserialize(IDataReader reader)
    {
    }
}