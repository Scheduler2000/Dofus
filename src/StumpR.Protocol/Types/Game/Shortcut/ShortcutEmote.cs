using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class ShortcutEmote : Shortcut
{
    public new const short Id = 3292;

    public ShortcutEmote(sbyte slot, ushort emoteId)
    {
        Slot = slot;
        EmoteId = emoteId;
    }

    public ShortcutEmote()
    {
    }

    public override short TypeId => Id;

    public ushort EmoteId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteUShort(EmoteId);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        EmoteId = reader.ReadUShort();
    }
}