using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class CharactersListRequestMessage : Message
{
    public const uint Id = 1501;

    public override uint MessageId => Id;

    public override void Serialize(IDataWriter writer)
    {
    }

    public override void Deserialize(IDataReader reader)
    {
    }
}