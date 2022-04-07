using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ContactLookErrorMessage : Message
{
    public const uint Id = 9873;

    public ContactLookErrorMessage(uint requestId)
    {
        RequestId = requestId;
    }

    public ContactLookErrorMessage()
    {
    }

    public override uint MessageId => Id;

    public uint RequestId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarUInt(RequestId);
    }

    public override void Deserialize(IDataReader reader)
    {
        RequestId = reader.ReadVarUInt();
    }
}