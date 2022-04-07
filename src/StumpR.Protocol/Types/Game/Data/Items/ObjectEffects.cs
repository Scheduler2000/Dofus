using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class ObjectEffects
{
    public const short Id = 5613;

    public ObjectEffects(IEnumerable<ObjectEffect> effects)
    {
        Effects = effects;
    }

    public ObjectEffects()
    {
    }

    public virtual short TypeId => Id;

    public IEnumerable<ObjectEffect> Effects { get; set; }

    public virtual void Serialize(IDataWriter writer)
    {
        writer.WriteShort((short) Effects.Count());

        foreach (ObjectEffect objectToSend in Effects)
        {
            writer.WriteShort(objectToSend.TypeId);
            objectToSend.Serialize(writer);
        }
    }

    public virtual void Deserialize(IDataReader reader)
    {
        ushort effectsCount = reader.ReadUShort();
        var effects_ = new ObjectEffect[effectsCount];

        for (var effectsIndex = 0; effectsIndex < effectsCount; effectsIndex++)
        {
            var objectToAdd = ProtocolTypeManager.GetInstance<ObjectEffect>(reader.ReadShort());
            objectToAdd.Deserialize(reader);
            effects_[effectsIndex] = objectToAdd;
        }
        Effects = effects_;
    }
}