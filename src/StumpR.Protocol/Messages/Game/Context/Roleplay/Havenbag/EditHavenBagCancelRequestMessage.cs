using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class EditHavenBagCancelRequestMessage : Message
{
    public const uint Id = 5731;

    public override uint MessageId => Id;

    public override void Serialize(IDataWriter writer)
    {
    }

    public override void Deserialize(IDataReader reader)
    {
    }
}