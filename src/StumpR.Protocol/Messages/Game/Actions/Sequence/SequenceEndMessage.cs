using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class SequenceEndMessage : Message
{
    public const uint Id = 5912;

    public SequenceEndMessage(ushort actionId, double authorId, sbyte sequenceType)
    {
        ActionId = actionId;
        AuthorId = authorId;
        SequenceType = sequenceType;
    }

    public SequenceEndMessage()
    {
    }

    public override uint MessageId => Id;

    public ushort ActionId { get; set; }

    public double AuthorId { get; set; }

    public sbyte SequenceType { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarUShort(ActionId);
        writer.WriteDouble(AuthorId);
        writer.WriteSByte(SequenceType);
    }

    public override void Deserialize(IDataReader reader)
    {
        ActionId = reader.ReadVarUShort();
        AuthorId = reader.ReadDouble();
        SequenceType = reader.ReadSByte();
    }
}