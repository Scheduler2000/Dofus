using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ActivityHideRequestMessage : Message
{
    public const uint Id = 9127;

    public ActivityHideRequestMessage(ushort activityId)
    {
        ActivityId = activityId;
    }

    public ActivityHideRequestMessage()
    {
    }

    public override uint MessageId => Id;

    public ushort ActivityId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarUShort(ActivityId);
    }

    public override void Deserialize(IDataReader reader)
    {
        ActivityId = reader.ReadVarUShort();
    }
}