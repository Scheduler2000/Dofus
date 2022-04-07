using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class BasicNoOperationMessage : Message
{
    public const uint Id = 2522;

    public override uint MessageId => Id;

    public override void Serialize(IDataWriter writer)
    {
    }

    public override void Deserialize(IDataReader reader)
    {
    }
}