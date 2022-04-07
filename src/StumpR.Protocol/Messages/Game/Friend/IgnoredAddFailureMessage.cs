using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class IgnoredAddFailureMessage : Message
{
    public const uint Id = 4052;

    public IgnoredAddFailureMessage(sbyte reason)
    {
        Reason = reason;
    }

    public IgnoredAddFailureMessage()
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