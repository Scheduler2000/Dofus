using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class FriendWarnOnLevelGainStateMessage : Message
{
    public const uint Id = 7352;

    public FriendWarnOnLevelGainStateMessage(bool enable)
    {
        Enable = enable;
    }

    public FriendWarnOnLevelGainStateMessage()
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