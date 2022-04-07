using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ShortcutBarAddRequestMessage : Message
{
    public const uint Id = 9513;

    public ShortcutBarAddRequestMessage(sbyte barType, Shortcut shortcut)
    {
        BarType = barType;
        Shortcut = shortcut;
    }

    public ShortcutBarAddRequestMessage()
    {
    }

    public override uint MessageId => Id;

    public sbyte BarType { get; set; }

    public Shortcut Shortcut { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteSByte(BarType);
        writer.WriteShort(Shortcut.TypeId);
        Shortcut.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        BarType = reader.ReadSByte();
        Shortcut = ProtocolTypeManager.GetInstance<Shortcut>(reader.ReadShort());
        Shortcut.Deserialize(reader);
    }
}