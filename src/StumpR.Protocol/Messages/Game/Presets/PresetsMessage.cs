using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class PresetsMessage : Message
{
    public const uint Id = 1706;

    public PresetsMessage(IEnumerable<Preset> presets)
    {
        Presets = presets;
    }

    public PresetsMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<Preset> Presets { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort((short) Presets.Count());

        foreach (Preset objectToSend in Presets)
        {
            writer.WriteShort(objectToSend.TypeId);
            objectToSend.Serialize(writer);
        }
    }

    public override void Deserialize(IDataReader reader)
    {
        ushort presetsCount = reader.ReadUShort();
        var presets_ = new Preset[presetsCount];

        for (var presetsIndex = 0; presetsIndex < presetsCount; presetsIndex++)
        {
            var objectToAdd = ProtocolTypeManager.GetInstance<Preset>(reader.ReadShort());
            objectToAdd.Deserialize(reader);
            presets_[presetsIndex] = objectToAdd;
        }
        Presets = presets_;
    }
}