using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class DebtInformation
{
    public const short Id = 9735;

    public DebtInformation(double objectId, double timestamp)
    {
        ObjectId = objectId;
        Timestamp = timestamp;
    }

    public DebtInformation()
    {
    }

    public virtual short TypeId => Id;

    public double ObjectId { get; set; }

    public double Timestamp { get; set; }

    public virtual void Serialize(IDataWriter writer)
    {
        writer.WriteDouble(ObjectId);
        writer.WriteDouble(Timestamp);
    }

    public virtual void Deserialize(IDataReader reader)
    {
        ObjectId = reader.ReadDouble();
        Timestamp = reader.ReadDouble();
    }
}