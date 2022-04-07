using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class IconPresetSaveRequestMessage : Message
{
    public const uint Id = 4898;

    public IconPresetSaveRequestMessage(short presetId, sbyte symbolId, bool updateData)
    {
        PresetId = presetId;
        SymbolId = symbolId;
        UpdateData = updateData;
    }

    public IconPresetSaveRequestMessage()
    {
    }

    public override uint MessageId => Id;

    public short PresetId { get; set; }

    public sbyte SymbolId { get; set; }

    public bool UpdateData { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort(PresetId);
        writer.WriteSByte(SymbolId);
        writer.WriteBoolean(UpdateData);
    }

    public override void Deserialize(IDataReader reader)
    {
        PresetId = reader.ReadShort();
        SymbolId = reader.ReadSByte();
        UpdateData = reader.ReadBoolean();
    }
}