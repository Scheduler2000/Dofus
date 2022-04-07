using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class CloseHavenBagFurnitureSequenceRequestMessage : Message
{
    public const uint Id = 3890;

    public override uint MessageId => Id;

    public override void Serialize(IDataWriter writer)
    {
    }

    public override void Deserialize(IDataReader reader)
    {
    }
}