using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class PresetsContainerPreset : Preset
{
    public new const short Id = 4853;

    public PresetsContainerPreset(short objectId, IEnumerable<Preset> presets)
    {
        ObjectId = objectId;
        Presets = presets;
    }

    public PresetsContainerPreset()
    {
    }

    public override short TypeId => Id;

    public IEnumerable<Preset> Presets { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteShort((short) Presets.Count());

        foreach (Preset objectToSend in Presets)
        {
            writer.WriteShort(objectToSend.TypeId);
            objectToSend.Serialize(writer);
        }
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
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