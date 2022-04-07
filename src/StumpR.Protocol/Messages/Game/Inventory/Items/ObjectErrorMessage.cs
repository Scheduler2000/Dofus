using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ObjectErrorMessage : Message
{
    public const uint Id = 9603;

    public ObjectErrorMessage(sbyte reason)
    {
        Reason = reason;
    }

    public ObjectErrorMessage()
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