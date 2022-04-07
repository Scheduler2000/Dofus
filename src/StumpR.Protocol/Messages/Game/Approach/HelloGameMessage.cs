using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class HelloGameMessage : Message
{
    public const uint Id = 5237;

    public override uint MessageId => Id;

    public override void Serialize(IDataWriter writer)
    {
    }

    public override void Deserialize(IDataReader reader)
    {
    }
}