using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class FriendStatusShareStateMessage : Message
{
    public const uint Id = 433;

    public FriendStatusShareStateMessage(bool share)
    {
        Share = share;
    }

    public FriendStatusShareStateMessage()
    {
    }

    public override uint MessageId => Id;

    public bool Share { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteBoolean(Share);
    }

    public override void Deserialize(IDataReader reader)
    {
        Share = reader.ReadBoolean();
    }
}