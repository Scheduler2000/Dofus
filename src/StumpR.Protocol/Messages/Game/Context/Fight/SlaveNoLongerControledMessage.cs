using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class SlaveNoLongerControledMessage : Message
{
    public const uint Id = 4540;

    public SlaveNoLongerControledMessage(double masterId, double slaveId)
    {
        MasterId = masterId;
        SlaveId = slaveId;
    }

    public SlaveNoLongerControledMessage()
    {
    }

    public override uint MessageId => Id;

    public double MasterId { get; set; }

    public double SlaveId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteDouble(MasterId);
        writer.WriteDouble(SlaveId);
    }

    public override void Deserialize(IDataReader reader)
    {
        MasterId = reader.ReadDouble();
        SlaveId = reader.ReadDouble();
    }
}