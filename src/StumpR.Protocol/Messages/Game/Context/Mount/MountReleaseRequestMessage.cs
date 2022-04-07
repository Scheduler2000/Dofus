using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class MountReleaseRequestMessage : Message
{
    public const uint Id = 5543;

    public override uint MessageId => Id;

    public override void Serialize(IDataWriter writer)
    {
    }

    public override void Deserialize(IDataReader reader)
    {
    }
}