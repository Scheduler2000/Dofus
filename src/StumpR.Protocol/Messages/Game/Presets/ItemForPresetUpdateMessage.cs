using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ItemForPresetUpdateMessage : Message
{
    public const uint Id = 2377;

    public ItemForPresetUpdateMessage(short presetId, ItemForPreset presetItem)
    {
        PresetId = presetId;
        PresetItem = presetItem;
    }

    public ItemForPresetUpdateMessage()
    {
    }

    public override uint MessageId => Id;

    public short PresetId { get; set; }

    public ItemForPreset PresetItem { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort(PresetId);
        PresetItem.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        PresetId = reader.ReadShort();
        PresetItem = new ItemForPreset();
        PresetItem.Deserialize(reader);
    }
}