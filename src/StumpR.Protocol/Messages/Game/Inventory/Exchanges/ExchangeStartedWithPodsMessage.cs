using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ExchangeStartedWithPodsMessage : ExchangeStartedMessage
{
    public new const uint Id = 2123;

    public ExchangeStartedWithPodsMessage(sbyte exchangeType,
        double firstCharacterId,
        uint firstCharacterCurrentWeight,
        uint firstCharacterMaxWeight,
        double secondCharacterId,
        uint secondCharacterCurrentWeight,
        uint secondCharacterMaxWeight)
    {
        ExchangeType = exchangeType;
        FirstCharacterId = firstCharacterId;
        FirstCharacterCurrentWeight = firstCharacterCurrentWeight;
        FirstCharacterMaxWeight = firstCharacterMaxWeight;
        SecondCharacterId = secondCharacterId;
        SecondCharacterCurrentWeight = secondCharacterCurrentWeight;
        SecondCharacterMaxWeight = secondCharacterMaxWeight;
    }

    public ExchangeStartedWithPodsMessage()
    {
    }

    public override uint MessageId => Id;

    public double FirstCharacterId { get; set; }

    public uint FirstCharacterCurrentWeight { get; set; }

    public uint FirstCharacterMaxWeight { get; set; }

    public double SecondCharacterId { get; set; }

    public uint SecondCharacterCurrentWeight { get; set; }

    public uint SecondCharacterMaxWeight { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteDouble(FirstCharacterId);
        writer.WriteVarUInt(FirstCharacterCurrentWeight);
        writer.WriteVarUInt(FirstCharacterMaxWeight);
        writer.WriteDouble(SecondCharacterId);
        writer.WriteVarUInt(SecondCharacterCurrentWeight);
        writer.WriteVarUInt(SecondCharacterMaxWeight);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        FirstCharacterId = reader.ReadDouble();
        FirstCharacterCurrentWeight = reader.ReadVarUInt();
        FirstCharacterMaxWeight = reader.ReadVarUInt();
        SecondCharacterId = reader.ReadDouble();
        SecondCharacterCurrentWeight = reader.ReadVarUInt();
        SecondCharacterMaxWeight = reader.ReadVarUInt();
    }
}