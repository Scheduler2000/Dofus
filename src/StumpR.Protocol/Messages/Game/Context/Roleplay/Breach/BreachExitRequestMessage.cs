using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class BreachExitRequestMessage : Message
{
    public const uint Id = 4948;

    public override uint MessageId => Id;

    public override void Serialize(IDataWriter writer)
    {
    }

    public override void Deserialize(IDataReader reader)
    {
    }
}