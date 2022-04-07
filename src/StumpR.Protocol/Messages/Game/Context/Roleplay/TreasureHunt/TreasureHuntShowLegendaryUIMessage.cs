using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class TreasureHuntShowLegendaryUIMessage : Message
{
    public const uint Id = 117;

    public TreasureHuntShowLegendaryUIMessage(IEnumerable<ushort> availableLegendaryIds)
    {
        AvailableLegendaryIds = availableLegendaryIds;
    }

    public TreasureHuntShowLegendaryUIMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<ushort> AvailableLegendaryIds { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort((short) AvailableLegendaryIds.Count());
        foreach (ushort objectToSend in AvailableLegendaryIds) writer.WriteVarUShort(objectToSend);
    }

    public override void Deserialize(IDataReader reader)
    {
        ushort availableLegendaryIdsCount = reader.ReadUShort();
        var availableLegendaryIds_ = new ushort[availableLegendaryIdsCount];

        for (var availableLegendaryIdsIndex = 0; availableLegendaryIdsIndex < availableLegendaryIdsCount; availableLegendaryIdsIndex++)
            availableLegendaryIds_[availableLegendaryIdsIndex] = reader.ReadVarUShort();
        AvailableLegendaryIds = availableLegendaryIds_;
    }
}