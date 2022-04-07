using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ChannelEnablingChangeMessage : Message
{
    public const uint Id = 4041;

    public ChannelEnablingChangeMessage(sbyte channel, bool enable)
    {
        Channel = channel;
        Enable = enable;
    }

    public ChannelEnablingChangeMessage()
    {
    }

    public override uint MessageId => Id;

    public sbyte Channel { get; set; }

    public bool Enable { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteSByte(Channel);
        writer.WriteBoolean(Enable);
    }

    public override void Deserialize(IDataReader reader)
    {
        Channel = reader.ReadSByte();
        Enable = reader.ReadBoolean();
    }
}