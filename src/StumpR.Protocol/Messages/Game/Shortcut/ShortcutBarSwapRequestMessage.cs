using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ShortcutBarSwapRequestMessage : Message
{
    public const uint Id = 709;

    public ShortcutBarSwapRequestMessage(sbyte barType, sbyte firstSlot, sbyte secondSlot)
    {
        BarType = barType;
        FirstSlot = firstSlot;
        SecondSlot = secondSlot;
    }

    public ShortcutBarSwapRequestMessage()
    {
    }

    public override uint MessageId => Id;

    public sbyte BarType { get; set; }

    public sbyte FirstSlot { get; set; }

    public sbyte SecondSlot { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteSByte(BarType);
        writer.WriteSByte(FirstSlot);
        writer.WriteSByte(SecondSlot);
    }

    public override void Deserialize(IDataReader reader)
    {
        BarType = reader.ReadSByte();
        FirstSlot = reader.ReadSByte();
        SecondSlot = reader.ReadSByte();
    }
}