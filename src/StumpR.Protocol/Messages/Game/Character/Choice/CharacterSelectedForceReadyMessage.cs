using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class CharacterSelectedForceReadyMessage : Message
{
    public const uint Id = 6390;

    public override uint MessageId => Id;

    public override void Serialize(IDataWriter writer)
    {
    }

    public override void Deserialize(IDataReader reader)
    {
    }
}