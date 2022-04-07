using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class SubEntity
{
    public const short Id = 8670;

    public SubEntity(sbyte bindingPointCategory, sbyte bindingPointIndex, EntityLook subEntityLook)
    {
        BindingPointCategory = bindingPointCategory;
        BindingPointIndex = bindingPointIndex;
        SubEntityLook = subEntityLook;
    }

    public SubEntity()
    {
    }

    public virtual short TypeId => Id;

    public sbyte BindingPointCategory { get; set; }

    public sbyte BindingPointIndex { get; set; }

    public EntityLook SubEntityLook { get; set; }

    public virtual void Serialize(IDataWriter writer)
    {
        writer.WriteSByte(BindingPointCategory);
        writer.WriteSByte(BindingPointIndex);
        SubEntityLook.Serialize(writer);
    }

    public virtual void Deserialize(IDataReader reader)
    {
        BindingPointCategory = reader.ReadSByte();
        BindingPointIndex = reader.ReadSByte();
        SubEntityLook = new EntityLook();
        SubEntityLook.Deserialize(reader);
    }
}