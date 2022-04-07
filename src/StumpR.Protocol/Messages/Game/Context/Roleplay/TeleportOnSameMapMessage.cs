using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class TeleportOnSameMapMessage : Message
{
    public const uint Id = 9521;

    public TeleportOnSameMapMessage(double targetId, ushort cellId)
    {
        TargetId = targetId;
        CellId = cellId;
    }

    public TeleportOnSameMapMessage()
    {
    }

    public override uint MessageId => Id;

    public double TargetId { get; set; }

    public ushort CellId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteDouble(TargetId);
        writer.WriteVarUShort(CellId);
    }

    public override void Deserialize(IDataReader reader)
    {
        TargetId = reader.ReadDouble();
        CellId = reader.ReadVarUShort();
    }
}