using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ShortcutBarRemoveRequestMessage : Message
{
    public const uint Id = 906;

    public ShortcutBarRemoveRequestMessage(sbyte barType, sbyte slot)
    {
        BarType = barType;
        Slot = slot;
    }

    public ShortcutBarRemoveRequestMessage()
    {
    }

    public override uint MessageId => Id;

    public sbyte BarType { get; set; }

    public sbyte Slot { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteSByte(BarType);
        writer.WriteSByte(Slot);
    }

    public override void Deserialize(IDataReader reader)
    {
        BarType = reader.ReadSByte();
        Slot = reader.ReadSByte();
    }
}