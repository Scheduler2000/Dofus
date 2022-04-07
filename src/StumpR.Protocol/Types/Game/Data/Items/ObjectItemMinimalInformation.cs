using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class ObjectItemMinimalInformation : Item
{
    public new const short Id = 4918;

    public ObjectItemMinimalInformation(ushort objectGID, IEnumerable<ObjectEffect> effects)
    {
        ObjectGID = objectGID;
        Effects = effects;
    }

    public ObjectItemMinimalInformation()
    {
    }

    public override short TypeId => Id;

    public ushort ObjectGID { get; set; }

    public IEnumerable<ObjectEffect> Effects { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteVarUShort(ObjectGID);
        writer.WriteShort((short) Effects.Count());

        foreach (ObjectEffect objectToSend in Effects)
        {
            writer.WriteShort(objectToSend.TypeId);
            objectToSend.Serialize(writer);
        }
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        ObjectGID = reader.ReadVarUShort();
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