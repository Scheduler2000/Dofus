using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class ShortcutSmiley : Shortcut
{
    public new const short Id = 4590;

    public ShortcutSmiley(sbyte slot, ushort smileyId)
    {
        Slot = slot;
        SmileyId = smileyId;
    }

    public ShortcutSmiley()
    {
    }

    public override short TypeId => Id;

    public ushort SmileyId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteVarUShort(SmileyId);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        SmileyId = reader.ReadVarUShort();
    }
}