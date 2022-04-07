using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class FriendSetStatusShareMessage : Message
{
    public const uint Id = 1404;

    public FriendSetStatusShareMessage(bool share)
    {
        Share = share;
    }

    public FriendSetStatusShareMessage()
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