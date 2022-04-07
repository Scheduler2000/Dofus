using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class NicknameAcceptedMessage : Message
{
    public const uint Id = 9067;

    public override uint MessageId => Id;

    public override void Serialize(IDataWriter writer)
    {
    }

    public override void Deserialize(IDataReader reader)
    {
    }
}