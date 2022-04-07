using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class AccountLoggingKickedMessage : Message
{
    public const uint Id = 7661;

    public AccountLoggingKickedMessage(ushort days, sbyte hours, sbyte minutes)
    {
        Days = days;
        Hours = hours;
        Minutes = minutes;
    }

    public AccountLoggingKickedMessage()
    {
    }

    public override uint MessageId => Id;

    public ushort Days { get; set; }

    public sbyte Hours { get; set; }

    public sbyte Minutes { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarUShort(Days);
        writer.WriteSByte(Hours);
        writer.WriteSByte(Minutes);
    }

    public override void Deserialize(IDataReader reader)
    {
        Days = reader.ReadVarUShort();
        Hours = reader.ReadSByte();
        Minutes = reader.ReadSByte();
    }
}