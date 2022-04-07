using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ObjectAveragePricesMessage : Message
{
    public const uint Id = 5921;

    public ObjectAveragePricesMessage(IEnumerable<ushort> ids, IEnumerable<ulong> avgPrices)
    {
        Ids = ids;
        AvgPrices = avgPrices;
    }

    public ObjectAveragePricesMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<ushort> Ids { get; set; }

    public IEnumerable<ulong> AvgPrices { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort((short) Ids.Count());
        foreach (ushort objectToSend in Ids) writer.WriteVarUShort(objectToSend);
        writer.WriteShort((short) AvgPrices.Count());
        foreach (ulong objectToSend in AvgPrices) writer.WriteVarULong(objectToSend);
    }

    public override void Deserialize(IDataReader reader)
    {
        ushort idsCount = reader.ReadUShort();
        var ids_ = new ushort[idsCount];
        for (var idsIndex = 0; idsIndex < idsCount; idsIndex++) ids_[idsIndex] = reader.ReadVarUShort();
        Ids = ids_;
        ushort avgPricesCount = reader.ReadUShort();
        var avgPrices_ = new ulong[avgPricesCount];

        for (var avgPricesIndex = 0; avgPricesIndex < avgPricesCount; avgPricesIndex++)
            avgPrices_[avgPricesIndex] = reader.ReadVarULong();
        AvgPrices = avgPrices_;
    }
}