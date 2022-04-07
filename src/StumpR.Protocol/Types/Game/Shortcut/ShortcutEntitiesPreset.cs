using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class ShortcutEntitiesPreset : Shortcut
{
    public new const short Id = 3590;

    public ShortcutEntitiesPreset(sbyte slot, short presetId)
    {
        Slot = slot;
        PresetId = presetId;
    }

    public ShortcutEntitiesPreset()
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