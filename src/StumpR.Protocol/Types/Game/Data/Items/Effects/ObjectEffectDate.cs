using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class ObjectEffectDate : ObjectEffect
{
    public new const short Id = 5415;

    public ObjectEffectDate(ushort actionId, ushort year, sbyte month, sbyte day, sbyte hour, sbyte minute)
    {
        ActionId = actionId;
        Year = year;
        Month = month;
        Day = day;
        Hour = hour;
        Minute = minute;
    }

    public ObjectEffectDate()
    {
    }

    public override short TypeId => Id;

    public ushort Year { get; set; }

    public sbyte Month { get; set; }

    public sbyte Day { get; set; }

    public sbyte Hour { get; set; }

    public sbyte Minute { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteVarUShort(Year);
        writer.WriteSByte(Month);
        writer.WriteSByte(Day);
        writer.WriteSByte(Hour);
        writer.WriteSByte(Minute);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        Year = reader.ReadVarUShort();
        Month = reader.ReadSByte();
        Day = reader.ReadSByte();
        Hour = reader.ReadSByte();
        Minute = reader.ReadSByte();
    }
}