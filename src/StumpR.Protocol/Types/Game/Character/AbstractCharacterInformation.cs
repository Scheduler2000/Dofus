using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class AbstractCharacterInformation
{
    public const short Id = 2714;

    public AbstractCharacterInformation(ulong objectId)
    {
        ObjectId = objectId;
    }

    public AbstractCharacterInformation()
    {
    }

    public virtual short TypeId => Id;

    public ulong ObjectId { get; set; }

    public virtual void Serialize(IDataWriter writer)
    {
        writer.WriteVarULong(ObjectId);
    }

    public virtual void Deserialize(IDataReader reader)
    {
        ObjectId = reader.ReadVarULong();
    }
}