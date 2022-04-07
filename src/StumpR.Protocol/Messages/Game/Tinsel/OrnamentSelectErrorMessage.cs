using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class OrnamentSelectErrorMessage : Message
{
    public const uint Id = 4098;

    public OrnamentSelectErrorMessage(sbyte reason)
    {
        Reason = reason;
    }

    public OrnamentSelectErrorMessage()
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