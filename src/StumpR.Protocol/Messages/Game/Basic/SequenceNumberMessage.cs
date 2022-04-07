using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class SequenceNumberMessage : Message
{
    public const uint Id = 1059;

    public SequenceNumberMessage(ushort number)
    {
        Number = number;
    }

    public SequenceNumberMessage()
    {
    }

    public override uint MessageId => Id;

    public ushort Number { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteUShort(Number);
    }

    public override void Deserialize(IDataReader reader)
    {
        Number = reader.ReadUShort();
    }
}