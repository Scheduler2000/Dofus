using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ObtainedItemMessage : Message
{
    public const uint Id = 4201;

    public ObtainedItemMessage(ushort genericId, uint baseQuantity)
    {
        GenericId = genericId;
        BaseQuantity = baseQuantity;
    }

    public ObtainedItemMessage()
    {
    }

    public override uint MessageId => Id;

    public ushort GenericId { get; set; }

    public uint BaseQuantity { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarUShort(GenericId);
        writer.WriteVarUInt(BaseQuantity);
    }

    public override void Deserialize(IDataReader reader)
    {
        GenericId = reader.ReadVarUShort();
        BaseQuantity = reader.ReadVarUInt();
    }
}