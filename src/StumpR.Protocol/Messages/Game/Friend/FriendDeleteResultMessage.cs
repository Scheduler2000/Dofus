using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class FriendDeleteResultMessage : Message
{
    public const uint Id = 8619;

    public FriendDeleteResultMessage(bool success, AccountTagInformation tag)
    {
        Success = success;
        Tag = tag;
    }

    public FriendDeleteResultMessage()
    {
    }

    public override uint MessageId => Id;

    public bool Success { get; set; }

    public AccountTagInformation Tag { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteBoolean(Success);
        Tag.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        Success = reader.ReadBoolean();
        Tag = new AccountTagInformation();
        Tag.Deserialize(reader);
    }
}