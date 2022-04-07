using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class CharacterLoadingCompleteMessage : Message
{
    public const uint Id = 9063;

    public override uint MessageId => Id;

    public override void Serialize(IDataWriter writer)
    {
    }

    public override void Deserialize(IDataReader reader)
    {
    }
}