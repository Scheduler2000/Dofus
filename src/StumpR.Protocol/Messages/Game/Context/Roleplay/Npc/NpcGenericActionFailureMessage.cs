using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class NpcGenericActionFailureMessage : Message
{
    public const uint Id = 1901;

    public override uint MessageId => Id;

    public override void Serialize(IDataWriter writer)
    {
    }

    public override void Deserialize(IDataReader reader)
    {
    }
}