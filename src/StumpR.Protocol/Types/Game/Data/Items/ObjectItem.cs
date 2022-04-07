using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class ObjectItem : Item
{
    public new const short Id = 2916;

    public ObjectItem(short position, ushort objectGID, IEnumerable<ObjectEffect> effects, uint objectUID, uint quantity)
    {
        Position = position;
        ObjectGID = objectGID;
        Effects = effects;
        ObjectUID = objectUID;
        Quantity = quantity;
    }

    public ObjectItem()
    {
    }

    public override short TypeId => Id;

    public short Position { get; set; }

    public ushort ObjectGID { get; set; }

    public IEnumerable<ObjectEffect> Effects { get; set; }

    public uint ObjectUID { get; set; }

    public uint Quantity { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteShort(Position);
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
        Position = reader.ReadShort();
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