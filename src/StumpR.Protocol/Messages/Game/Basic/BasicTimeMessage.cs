using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class BasicTimeMessage : Message
{
    public const uint Id = 7278;

    public BasicTimeMessage(double timestamp, short timezoneOffset)
    {
        Timestamp = timestamp;
        TimezoneOffset = timezoneOffset;
    }

    public BasicTimeMessage()
    {
    }

    public override uint MessageId => Id;

    public double Timestamp { get; set; }

    public short TimezoneOffset { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteDouble(Timestamp);
        writer.WriteShort(TimezoneOffset);
    }

    public override void Deserialize(IDataReader reader)
    {
        Timestamp = reader.ReadDouble();
        TimezoneOffset = reader.ReadShort();
    }
}