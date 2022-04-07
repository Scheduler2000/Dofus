using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ExchangeHandleMountsMessage : Message
{
    public const uint Id = 9421;

    public ExchangeHandleMountsMessage(sbyte actionType, IEnumerable<uint> ridesId)
    {
        ActionType = actionType;
        RidesId = ridesId;
    }

    public ExchangeHandleMountsMessage()
    {
    }

    public override uint MessageId => Id;

    public sbyte ActionType { get; set; }

    public IEnumerable<uint> RidesId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteSByte(ActionType);
        writer.WriteShort((short) RidesId.Count());
        foreach (uint objectToSend in RidesId) writer.WriteVarUInt(objectToSend);
    }

    public override void Deserialize(IDataReader reader)
    {
        ActionType = reader.ReadSByte();
        ushort ridesIdCount = reader.ReadUShort();
        var ridesId_ = new uint[ridesIdCount];
        for (var ridesIdIndex = 0; ridesIdIndex < ridesIdCount; ridesIdIndex++) ridesId_[ridesIdIndex] = reader.ReadVarUInt();
        RidesId = ridesId_;
    }
}