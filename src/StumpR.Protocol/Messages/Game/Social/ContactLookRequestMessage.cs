using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ContactLookRequestMessage : Message
{
    public const uint Id = 9165;

    public ContactLookRequestMessage(byte requestId, sbyte contactType)
    {
        RequestId = requestId;
        ContactType = contactType;
    }

    public ContactLookRequestMessage()
    {
    }

    public override uint MessageId => Id;

    public byte RequestId { get; set; }

    public sbyte ContactType { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteByte(RequestId);
        writer.WriteSByte(ContactType);
    }

    public override void Deserialize(IDataReader reader)
    {
        RequestId = reader.ReadByte();
        ContactType = reader.ReadSByte();
    }
}