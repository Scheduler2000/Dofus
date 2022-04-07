using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class FriendSetWarnOnLevelGainMessage : Message
{
    public const uint Id = 4065;

    public FriendSetWarnOnLevelGainMessage(bool enable)
    {
        Enable = enable;
    }

    public FriendSetWarnOnLevelGainMessage()
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