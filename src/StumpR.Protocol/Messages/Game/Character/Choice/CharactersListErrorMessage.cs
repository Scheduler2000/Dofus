using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class CharactersListErrorMessage : Message
{
    public const uint Id = 6129;

    public override uint MessageId => Id;

    public override void Serialize(IDataWriter writer)
    {
    }

    public override void Deserialize(IDataReader reader)
    {
    }
}