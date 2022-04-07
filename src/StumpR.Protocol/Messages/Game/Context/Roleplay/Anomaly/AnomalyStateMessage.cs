using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class AnomalyStateMessage : Message
{
    public const uint Id = 4879;

    public AnomalyStateMessage(ushort subAreaId, bool open, ulong closingTime)
    {
        SubAreaId = subAreaId;
        Open = open;
        ClosingTime = closingTime;
    }

    public AnomalyStateMessage()
    {
    }

    public override uint MessageId => Id;

    public ushort SubAreaId { get; set; }

    public bool Open { get; set; }

    public ulong ClosingTime { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarUShort(SubAreaId);
        writer.WriteBoolean(Open);
        writer.WriteVarULong(ClosingTime);
    }

    public override void Deserialize(IDataReader reader)
    {
        SubAreaId = reader.ReadVarUShort();
        Open = reader.ReadBoolean();
        ClosingTime = reader.ReadVarULong();
    }
}