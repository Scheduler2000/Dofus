using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class ObjectItemNotInContainer : Item
{
    public new const short Id = 8362;

    public ObjectItemNotInContainer(ushort objectGID, IEnumerable<ObjectEffect> effects, uint objectUID, uint quantity)
    {
        ObjectGID = objectGID;
        Effects = effects;
        ObjectUID = objectUID;
        Quantity = quantity;
    }

    public ObjectItemNotInContainer()
    {
    }

    public override short TypeId => Id;

    public ushort ObjectGID { get; set; }

    public IEnumerable<ObjectEffect> Effects { get; set; }

    public uint ObjectUID { get; set; }

    public uint Quantity { get; set; }

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
        writer.WriteVarUInt(ObjectUID);
        writer.WriteVarUInt(Quantity);
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
        ObjectUID = reader.ReadVarUInt();
        Quantity = reader.ReadVarUInt();
    }
}