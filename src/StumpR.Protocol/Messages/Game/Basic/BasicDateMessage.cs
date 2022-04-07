using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class BasicDateMessage : Message
{
    public const uint Id = 4911;

    public BasicDateMessage(sbyte day, sbyte month, short year)
    {
        Day = day;
        Month = month;
        Year = year;
    }

    public BasicDateMessage()
    {
    }

    public override uint MessageId => Id;

    public sbyte Day { get; set; }

    public sbyte Month { get; set; }

    public short Year { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteSByte(Day);
        writer.WriteSByte(Month);
        writer.WriteShort(Year);
    }

    public override void Deserialize(IDataReader reader)
    {
        Day = reader.ReadSByte();
        Month = reader.ReadSByte();
        Year = reader.ReadShort();
    }
}