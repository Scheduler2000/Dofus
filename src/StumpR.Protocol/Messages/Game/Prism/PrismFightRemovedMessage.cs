using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class PrismFightRemovedMessage : Message
{
    public const uint Id = 9563;

    public PrismFightRemovedMessage(ushort subAreaId)
    {
        SubAreaId = subAreaId;
    }

    public PrismFightRemovedMessage()
    {
    }

    public override uint MessageId => Id;

    public ushort SubAreaId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarUShort(SubAreaId);
    }

    public override void Deserialize(IDataReader reader)
    {
        SubAreaId = reader.ReadVarUShort();
    }
}