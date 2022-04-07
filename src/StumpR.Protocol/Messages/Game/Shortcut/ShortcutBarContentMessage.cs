using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ShortcutBarContentMessage : Message
{
    public const uint Id = 7910;

    public ShortcutBarContentMessage(sbyte barType, IEnumerable<Shortcut> shortcuts)
    {
        BarType = barType;
        Shortcuts = shortcuts;
    }

    public ShortcutBarContentMessage()
    {
    }

    public override uint MessageId => Id;

    public sbyte BarType { get; set; }

    public IEnumerable<Shortcut> Shortcuts { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteSByte(BarType);
        writer.WriteShort((short) Shortcuts.Count());

        foreach (Shortcut objectToSend in Shortcuts)
        {
            writer.WriteShort(objectToSend.TypeId);
            objectToSend.Serialize(writer);
        }
    }

    public override void Deserialize(IDataReader reader)
    {
        BarType = reader.ReadSByte();
        ushort shortcutsCount = reader.ReadUShort();
        var shortcuts_ = new Shortcut[shortcutsCount];

        for (var shortcutsIndex = 0; shortcutsIndex < shortcutsCount; shortcutsIndex++)
        {
            var objectToAdd = ProtocolTypeManager.GetInstance<Shortcut>(reader.ReadShort());
            objectToAdd.Deserialize(reader);
            shortcuts_[shortcutsIndex] = objectToAdd;
        }
        Shortcuts = shortcuts_;
    }
}