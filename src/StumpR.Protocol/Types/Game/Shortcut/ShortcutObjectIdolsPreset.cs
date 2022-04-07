using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class ShortcutObjectIdolsPreset : ShortcutObject
{
    public new const short Id = 83;

    public ShortcutObjectIdolsPreset(sbyte slot, short presetId)
    {
        Slot = slot;
        PresetId = presetId;
    }

    public ShortcutObjectIdolsPreset()
    {
    }

    public override short TypeId => Id;

    public short PresetId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteShort(PresetId);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        PresetId = reader.ReadShort();
    }
}