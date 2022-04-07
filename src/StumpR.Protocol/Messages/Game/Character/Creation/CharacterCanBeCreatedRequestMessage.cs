using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class CharacterCanBeCreatedRequestMessage : Message
{
    public const uint Id = 6208;

    public override uint MessageId => Id;

    public override void Serialize(IDataWriter writer)
    {
    }

    public override void Deserialize(IDataReader reader)
    {
    }
}