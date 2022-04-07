using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class PartyEntityBaseInformation
{
    public const short Id = 8087;

    public PartyEntityBaseInformation(sbyte indexId, sbyte entityModelId, EntityLook entityLook)
    {
        IndexId = indexId;
        EntityModelId = entityModelId;
        EntityLook = entityLook;
    }

    public PartyEntityBaseInformation()
    {
    }

    public virtual short TypeId => Id;

    public sbyte IndexId { get; set; }

    public sbyte EntityModelId { get; set; }

    public EntityLook EntityLook { get; set; }

    public virtual void Serialize(IDataWriter writer)
    {
        writer.WriteSByte(IndexId);
        writer.WriteSByte(EntityModelId);
        EntityLook.Serialize(writer);
    }

    public virtual void Deserialize(IDataReader reader)
    {
        IndexId = reader.ReadSByte();
        EntityModelId = reader.ReadSByte();
        EntityLook = new EntityLook();
        EntityLook.Deserialize(reader);
    }
}