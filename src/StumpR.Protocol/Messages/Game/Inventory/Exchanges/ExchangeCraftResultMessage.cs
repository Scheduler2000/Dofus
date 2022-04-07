using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ExchangeCraftResultMessage : Message
{
    public const uint Id = 8524;

    public ExchangeCraftResultMessage(sbyte craftResult)
    {
        CraftResult = craftResult;
    }

    public ExchangeCraftResultMessage()
    {
    }

    public override uint MessageId => Id;

    public sbyte CraftResult { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteSByte(CraftResult);
    }

    public override void Deserialize(IDataReader reader)
    {
        CraftResult = reader.ReadSByte();
    }
}