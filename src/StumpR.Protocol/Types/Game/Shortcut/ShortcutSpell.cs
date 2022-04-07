using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class ShortcutSpell : Shortcut
{
    public new const short Id = 445;

    public ShortcutSpell(sbyte slot, ushort spellId)
    {
        Slot = slot;
        SpellId = spellId;
    }

    public ShortcutSpell()
    {
    }

    public override short TypeId => Id;

    public ushort SpellId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteVarUShort(SpellId);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        SpellId = reader.ReadVarUShort();
    }
}