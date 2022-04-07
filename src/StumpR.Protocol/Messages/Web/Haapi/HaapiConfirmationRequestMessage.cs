using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class HaapiConfirmationRequestMessage : Message
{
    public const uint Id = 5599;

    public HaapiConfirmationRequestMessage(ulong kamas, ulong ogrines, ushort rate, sbyte action)
    {
        Kamas = kamas;
        Ogrines = ogrines;
        Rate = rate;
        Action = action;
    }

    public HaapiConfirmationRequestMessage()
    {
    }

    public override uint MessageId => Id;

    public ulong Kamas { get; set; }

    public ulong Ogrines { get; set; }

    public ushort Rate { get; set; }

    public sbyte Action { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarULong(Kamas);
        writer.WriteVarULong(Ogrines);
        writer.WriteVarUShort(Rate);
        writer.WriteSByte(Action);
    }

    public override void Deserialize(IDataReader reader)
    {
        Kamas = reader.ReadVarULong();
        Ogrines = reader.ReadVarULong();
        Rate = reader.ReadVarUShort();
        Action = reader.ReadSByte();
    }
}