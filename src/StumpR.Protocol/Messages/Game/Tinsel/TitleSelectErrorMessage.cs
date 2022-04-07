using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class TitleSelectErrorMessage : Message
{
    public const uint Id = 2014;

    public TitleSelectErrorMessage(sbyte reason)
    {
        Reason = reason;
    }

    public TitleSelectErrorMessage()
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