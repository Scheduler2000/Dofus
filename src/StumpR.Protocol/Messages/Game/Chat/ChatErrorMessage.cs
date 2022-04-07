using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ChatErrorMessage : Message
{
    public const uint Id = 5479;

    public ChatErrorMessage(sbyte reason)
    {
        Reason = reason;
    }

    public ChatErrorMessage()
    {
    }

    public override uint MessageId => Id;

    public sbyte Reason { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteSByte(Reason);
    }

    public override void Deserialize(IDataReader reader)
    {
        Reason = reader.ReadSByte();
    }
}