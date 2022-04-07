using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class IndexedEntityLook
{
    public const short Id = 1904;

    public IndexedEntityLook(EntityLook look, sbyte index)
    {
        Look = look;
        Index = index;
    }

    public IndexedEntityLook()
    {
    }

    public virtual short TypeId => Id;

    public EntityLook Look { get; set; }

    public sbyte Index { get; set; }

    public virtual void Serialize(IDataWriter writer)
    {
        Look.Serialize(writer);
        writer.WriteSByte(Index);
    }

    public virtual void Deserialize(IDataReader reader)
    {
        Look = new EntityLook();
        Look.Deserialize(reader);
        Index = reader.ReadSByte();
    }
}