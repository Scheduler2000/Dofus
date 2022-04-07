using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class InvalidPresetsMessage : Message
{
    public const uint Id = 5030;

    public InvalidPresetsMessage(IEnumerable<short> presetIds)
    {
        PresetIds = presetIds;
    }

    public InvalidPresetsMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<short> PresetIds { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort((short) PresetIds.Count());
        foreach (short objectToSend in PresetIds) writer.WriteShort(objectToSend);
    }

    public override void Deserialize(IDataReader reader)
    {
        ushort presetIdsCount = reader.ReadUShort();
        var presetIds_ = new short[presetIdsCount];
        for (var presetIdsIndex = 0; presetIdsIndex < presetIdsCount; presetIdsIndex++) presetIds_[presetIdsIndex] = reader.ReadShort();
        PresetIds = presetIds_;
    }
}