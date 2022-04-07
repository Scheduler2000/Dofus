using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class IgnoredGetListMessage : Message
{
    public const uint Id = 4403;

    public override uint MessageId => Id;

    public override void Serialize(IDataWriter writer)
    {
    }

    public override void Deserialize(IDataReader reader)
    {
    }
}