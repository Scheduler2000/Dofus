using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class IconNamedPresetSaveRequestMessage : IconPresetSaveRequestMessage
{
    public new const uint Id = 8129;

    public IconNamedPresetSaveRequestMessage(short presetId, sbyte symbolId, bool updateData, string name, sbyte type)
    {
        PresetId = presetId;
        SymbolId = symbolId;
        UpdateData = updateData;
        Name = name;
        Type = type;
    }

    public IconNamedPresetSaveRequestMessage()
    {
    }

    public override uint MessageId => Id;

    public string Name { get; set; }

    public sbyte Type { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteUTF(Name);
        writer.WriteSByte(Type);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        Name = reader.ReadUTF();
        Type = reader.ReadSByte();
    }
}