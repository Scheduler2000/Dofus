using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GameContextDestroyMessage : Message
{
    public const uint Id = 7855;

    public override uint MessageId => Id;

    public override void Serialize(IDataWriter writer)
    {
    }

    public override void Deserialize(IDataReader reader)
    {
    }
}