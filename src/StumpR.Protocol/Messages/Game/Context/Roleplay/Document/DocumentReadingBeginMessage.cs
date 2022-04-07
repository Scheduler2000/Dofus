using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class DocumentReadingBeginMessage : Message
{
    public const uint Id = 3768;

    public DocumentReadingBeginMessage(ushort documentId)
    {
        DocumentId = documentId;
    }

    public DocumentReadingBeginMessage()
    {
    }

    public override uint MessageId => Id;

    public ushort DocumentId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarUShort(DocumentId);
    }

    public override void Deserialize(IDataReader reader)
    {
        DocumentId = reader.ReadVarUShort();
    }
}