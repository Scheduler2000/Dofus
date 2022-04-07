using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class DungeonPartyFinderAvailableDungeonsMessage : Message
{
    public const uint Id = 2640;

    public DungeonPartyFinderAvailableDungeonsMessage(IEnumerable<ushort> dungeonIds)
    {
        DungeonIds = dungeonIds;
    }

    public DungeonPartyFinderAvailableDungeonsMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<ushort> DungeonIds { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort((short) DungeonIds.Count());
        foreach (ushort objectToSend in DungeonIds) writer.WriteVarUShort(objectToSend);
    }

    public override void Deserialize(IDataReader reader)
    {
        ushort dungeonIdsCount = reader.ReadUShort();
        var dungeonIds_ = new ushort[dungeonIdsCount];

        for (var dungeonIdsIndex = 0; dungeonIdsIndex < dungeonIdsCount; dungeonIdsIndex++)
            dungeonIds_[dungeonIdsIndex] = reader.ReadVarUShort();
        DungeonIds = dungeonIds_;
    }
}