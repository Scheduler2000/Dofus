using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class DungeonPartyFinderRegisterSuccessMessage : Message
{
    public const uint Id = 2385;

    public DungeonPartyFinderRegisterSuccessMessage(IEnumerable<ushort> dungeonIds)
    {
        DungeonIds = dungeonIds;
    }

    public DungeonPartyFinderRegisterSuccessMessage()
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