using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class EntityInformation
{
    public const short Id = 6041;

    public EntityInformation(ushort objectId, uint experience, bool status)
    {
        ObjectId = objectId;
        Experience = experience;
        Status = status;
    }

    public EntityInformation()
    {
    }

    public virtual short TypeId => Id;

    public ushort ObjectId { get; set; }

    public uint Experience { get; set; }

    public bool Status { get; set; }

    public virtual void Serialize(IDataWriter writer)
    {
        writer.WriteVarUShort(ObjectId);
        writer.WriteVarUInt(Experience);
        writer.WriteBoolean(Status);
    }

    public virtual void Deserialize(IDataReader reader)
    {
        ObjectId = reader.ReadVarUShort();
        Experience = reader.ReadVarUInt();
        Status = reader.ReadBoolean();
    }
}