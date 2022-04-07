using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ShortcutBarReplacedMessage : Message
{
    public const uint Id = 5103;

    public ShortcutBarReplacedMessage(sbyte barType, Shortcut shortcut)
    {
        BarType = barType;
        Shortcut = shortcut;
    }

    public ShortcutBarReplacedMessage()
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