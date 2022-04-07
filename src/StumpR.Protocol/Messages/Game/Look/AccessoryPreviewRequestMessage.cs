using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class AccessoryPreviewRequestMessage : Message
{
    public const uint Id = 35;

    public AccessoryPreviewRequestMessage(IEnumerable<ushort> genericId)
    {
        GenericId = genericId;
    }

    public AccessoryPreviewRequestMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<ushort> GenericId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort((short) GenericId.Count());
        foreach (ushort objectToSend in GenericId) writer.WriteVarUShort(objectToSend);
    }

    public override void Deserialize(IDataReader reader)
    {
        ushort genericIdCount = reader.ReadUShort();
        var genericId_ = new ushort[genericIdCount];

        for (var genericIdIndex = 0; genericIdIndex < genericIdCount; genericIdIndex++)
            genericId_[genericIdIndex] = reader.ReadVarUShort();
        GenericId = genericId_;
    }
}