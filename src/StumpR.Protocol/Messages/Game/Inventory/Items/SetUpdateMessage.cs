using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class SetUpdateMessage : Message
{
    public const uint Id = 2982;

    public SetUpdateMessage(ushort setId, IEnumerable<ushort> setObjects, IEnumerable<ObjectEffect> setEffects)
    {
        SetId = setId;
        SetObjects = setObjects;
        SetEffects = setEffects;
    }

    public SetUpdateMessage()
    {
    }

    public override uint MessageId => Id;

    public ushort SetId { get; set; }

    public IEnumerable<ushort> SetObjects { get; set; }

    public IEnumerable<ObjectEffect> SetEffects { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarUShort(SetId);
        writer.WriteShort((short) SetObjects.Count());
        foreach (ushort objectToSend in SetObjects) writer.WriteVarUShort(objectToSend);
        writer.WriteShort((short) SetEffects.Count());

        foreach (ObjectEffect objectToSend in SetEffects)
        {
            writer.WriteShort(objectToSend.TypeId);
            objectToSend.Serialize(writer);
        }
    }

    public override void Deserialize(IDataReader reader)
    {
        SetId = reader.ReadVarUShort();
        ushort setObjectsCount = reader.ReadUShort();
        var setObjects_ = new ushort[setObjectsCount];

        for (var setObjectsIndex = 0; setObjectsIndex < setObjectsCount; setObjectsIndex++)
            setObjects_[setObjectsIndex] = reader.ReadVarUShort();
        SetObjects = setObjects_;
        ushort setEffectsCount = reader.ReadUShort();
        var setEffects_ = new ObjectEffect[setEffectsCount];

        for (var setEffectsIndex = 0; setEffectsIndex < setEffectsCount; setEffectsIndex++)
        {
            var objectToAdd = ProtocolTypeManager.GetInstance<ObjectEffect>(reader.ReadShort());
            objectToAdd.Deserialize(reader);
            setEffects_[setEffectsIndex] = objectToAdd;
        }
        SetEffects = setEffects_;
    }
}