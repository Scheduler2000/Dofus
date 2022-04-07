using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class EnabledChannelsMessage : Message
{
    public const uint Id = 9261;

    public EnabledChannelsMessage(IEnumerable<byte> channels, IEnumerable<byte> disallowed)
    {
        Channels = channels;
        Disallowed = disallowed;
    }

    public EnabledChannelsMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<byte> Channels { get; set; }

    public IEnumerable<byte> Disallowed { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort((short) Channels.Count());
        foreach (byte objectToSend in Channels) writer.WriteByte(objectToSend);
        writer.WriteShort((short) Disallowed.Count());
        foreach (byte objectToSend in Disallowed) writer.WriteByte(objectToSend);
    }

    public override void Deserialize(IDataReader reader)
    {
        ushort channelsCount = reader.ReadUShort();
        var channels_ = new byte[channelsCount];
        for (var channelsIndex = 0; channelsIndex < channelsCount; channelsIndex++) channels_[channelsIndex] = reader.ReadByte();
        Channels = channels_;
        ushort disallowedCount = reader.ReadUShort();
        var disallowed_ = new byte[disallowedCount];

        for (var disallowedIndex = 0; disallowedIndex < disallowedCount; disallowedIndex++)
            disallowed_[disallowedIndex] = reader.ReadByte();
        Disallowed = disallowed_;
    }
}