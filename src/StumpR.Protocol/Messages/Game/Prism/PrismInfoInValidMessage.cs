using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class PrismInfoInValidMessage : Message
{
    public const uint Id = 7307;

    public PrismInfoInValidMessage(sbyte reason)
    {
        Reason = reason;
    }

    public PrismInfoInValidMessage()
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