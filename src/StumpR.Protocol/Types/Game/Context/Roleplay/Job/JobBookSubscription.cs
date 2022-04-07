using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class JobBookSubscription
{
    public const short Id = 6658;

    public JobBookSubscription(sbyte jobId, bool subscribed)
    {
        JobId = jobId;
        Subscribed = subscribed;
    }

    public JobBookSubscription()
    {
    }

    public virtual short TypeId => Id;

    public sbyte JobId { get; set; }

    public bool Subscribed { get; set; }

    public virtual void Serialize(IDataWriter writer)
    {
        writer.WriteSByte(JobId);
        writer.WriteBoolean(Subscribed);
    }

    public virtual void Deserialize(IDataReader reader)
    {
        JobId = reader.ReadSByte();
        Subscribed = reader.ReadBoolean();
    }
}