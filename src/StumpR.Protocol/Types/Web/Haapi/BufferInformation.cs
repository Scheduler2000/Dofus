using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class BufferInformation
{
    public const short Id = 3684;

    public BufferInformation(ulong objectId, ulong amount)
    {
        ObjectId = objectId;
        Amount = amount;
    }

    public BufferInformation()
    {
    }

    public virtual short TypeId => Id;

    public ulong ObjectId { get; set; }

    public ulong Amount { get; set; }

    public virtual void Serialize(IDataWriter writer)
    {
        writer.WriteVarULong(ObjectId);
        writer.WriteVarULong(Amount);
    }

    public virtual void Deserialize(IDataReader reader)
    {
        ObjectId = reader.ReadVarULong();
        Amount = reader.ReadVarULong();
    }
}