using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class PrismFightSwapRequestMessage : Message
{
    public const uint Id = 4070;

    public PrismFightSwapRequestMessage(ushort subAreaId, ulong targetId)
    {
        SubAreaId = subAreaId;
        TargetId = targetId;
    }

    public PrismFightSwapRequestMessage()
    {
    }

    public override uint MessageId => Id;

    public ushort SubAreaId { get; set; }

    public ulong TargetId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarUShort(SubAreaId);
        writer.WriteVarULong(TargetId);
    }

    public override void Deserialize(IDataReader reader)
    {
        SubAreaId = reader.ReadVarUShort();
        TargetId = reader.ReadVarULong();
    }
}