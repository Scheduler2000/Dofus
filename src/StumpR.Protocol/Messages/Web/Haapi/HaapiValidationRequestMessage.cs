using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class HaapiValidationRequestMessage : Message
{
    public const uint Id = 3931;

    public HaapiValidationRequestMessage(string transaction)
    {
        Transaction = transaction;
    }

    public HaapiValidationRequestMessage()
    {
    }

    public override uint MessageId => Id;

    public string Transaction { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteUTF(Transaction);
    }

    public override void Deserialize(IDataReader reader)
    {
        Transaction = reader.ReadUTF();
    }
}