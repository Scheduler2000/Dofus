using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ExchangeErrorMessage : Message
{
    public const uint Id = 6446;

    public ExchangeErrorMessage(sbyte errorType)
    {
        ErrorType = errorType;
    }

    public ExchangeErrorMessage()
    {
    }

    public override uint MessageId => Id;

    public sbyte ErrorType { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteSByte(ErrorType);
    }

    public override void Deserialize(IDataReader reader)
    {
        ErrorType = reader.ReadSByte();
    }
}