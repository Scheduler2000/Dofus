using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class NotificationListMessage : Message
{
    public const uint Id = 7026;

    public NotificationListMessage(IEnumerable<int> flags)
    {
        Flags = flags;
    }

    public NotificationListMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<int> Flags { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort((short) Flags.Count());
        foreach (int objectToSend in Flags) writer.WriteVarInt(objectToSend);
    }

    public override void Deserialize(IDataReader reader)
    {
        ushort flagsCount = reader.ReadUShort();
        var flags_ = new int[flagsCount];
        for (var flagsIndex = 0; flagsIndex < flagsCount; flagsIndex++) flags_[flagsIndex] = reader.ReadVarInt();
        Flags = flags_;
    }
}