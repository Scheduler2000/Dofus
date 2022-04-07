using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class SpellForPreset
{
    public const short Id = 7500;

    public SpellForPreset(ushort spellId, IEnumerable<short> shortcuts)
    {
        SpellId = spellId;
        Shortcuts = shortcuts;
    }

    public SpellForPreset()
    {
    }

    public virtual short TypeId => Id;

    public ushort SpellId { get; set; }

    public IEnumerable<short> Shortcuts { get; set; }

    public virtual void Serialize(IDataWriter writer)
    {
        writer.WriteVarUShort(SpellId);
        writer.WriteShort((short) Shortcuts.Count());
        foreach (short objectToSend in Shortcuts) writer.WriteShort(objectToSend);
    }

    public virtual void Deserialize(IDataReader reader)
    {
        SpellId = reader.ReadVarUShort();
        ushort shortcutsCount = reader.ReadUShort();
        var shortcuts_ = new short[shortcutsCount];
        for (var shortcutsIndex = 0; shortcutsIndex < shortcutsCount; shortcutsIndex++) shortcuts_[shortcutsIndex] = reader.ReadShort();
        Shortcuts = shortcuts_;
    }
}