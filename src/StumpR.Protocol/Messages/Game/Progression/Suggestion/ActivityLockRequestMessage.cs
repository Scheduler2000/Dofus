using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ActivityLockRequestMessage : Message
{
    public const uint Id = 579;

    public ActivityLockRequestMessage(ushort activityId, bool @lock)
    {
        ActivityId = activityId;
        Lock = @lock;
    }

    public ActivityLockRequestMessage()
    {
    }

    public override uint MessageId => Id;

    public ushort ActivityId { get; set; }

    public bool Lock { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarUShort(ActivityId);
        writer.WriteBoolean(Lock);
    }

    public override void Deserialize(IDataReader reader)
    {
        ActivityId = reader.ReadVarUShort();
        Lock = reader.ReadBoolean();
    }
}