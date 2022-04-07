using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class IconNamedPreset : PresetsContainerPreset
{
    public new const short Id = 876;

    public IconNamedPreset(short objectId, IEnumerable<Preset> presets, short iconId, string name)
    {
        ObjectId = objectId;
        Presets = presets;
        IconId = iconId;
        Name = name;
    }

    public IconNamedPreset()
    {
    }

    public override short TypeId => Id;

    public short IconId { get; set; }

    public string Name { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteShort(IconId);
        writer.WriteUTF(Name);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        IconId = reader.ReadShort();
        Name = reader.ReadUTF();
    }
}