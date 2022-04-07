using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class FriendWarnOnConnectionStateMessage : Message
{
    public const uint Id = 6412;

    public FriendWarnOnConnectionStateMessage(bool enable)
    {
        Enable = enable;
    }

    public FriendWarnOnConnectionStateMessage()
    {
    }

    public override uint MessageId => Id;

    public bool Enable { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteBoolean(Enable);
    }

    public override void Deserialize(IDataReader reader)
    {
        Enable = reader.ReadBoolean();
    }
}