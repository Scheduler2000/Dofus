using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class WarnOnPermaDeathStateMessage : Message
{
    public const uint Id = 8629;

    public WarnOnPermaDeathStateMessage(bool enable)
    {
        Enable = enable;
    }

    public WarnOnPermaDeathStateMessage()
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