using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class ServerSessionConstant
{
    public const short Id = 7504;

    public ServerSessionConstant(ushort objectId)
    {
        ObjectId = objectId;
    }

    public ServerSessionConstant()
    {
    }

    public virtual short TypeId => Id;

    public ushort ObjectId { get; set; }

    public virtual void Serialize(IDataWriter writer)
    {
        writer.WriteVarUShort(ObjectId);
    }

    public virtual void Deserialize(IDataReader reader)
    {
        ObjectId = reader.ReadVarUShort();
    }
}