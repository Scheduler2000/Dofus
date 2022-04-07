using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class DungeonPartyFinderRoomContentUpdateMessage : Message
{
    public const uint Id = 6719;

    public DungeonPartyFinderRoomContentUpdateMessage(ushort dungeonId,
        IEnumerable<DungeonPartyFinderPlayer> addedPlayers,
        IEnumerable<ulong> removedPlayersIds)
    {
        DungeonId = dungeonId;
        AddedPlayers = addedPlayers;
        RemovedPlayersIds = removedPlayersIds;
    }

    public DungeonPartyFinderRoomContentUpdateMessage()
    {
    }

    public override uint MessageId => Id;

    public ushort DungeonId { get; set; }

    public IEnumerable<DungeonPartyFinderPlayer> AddedPlayers { get; set; }

    public IEnumerable<ulong> RemovedPlayersIds { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarUShort(DungeonId);
        writer.WriteShort((short) AddedPlayers.Count());
        foreach (DungeonPartyFinderPlayer objectToSend in AddedPlayers) objectToSend.Serialize(writer);
        writer.WriteShort((short) RemovedPlayersIds.Count());
        foreach (ulong objectToSend in RemovedPlayersIds) writer.WriteVarULong(objectToSend);
    }

    public override void Deserialize(IDataReader reader)
    {
        DungeonId = reader.ReadVarUShort();
        ushort addedPlayersCount = reader.ReadUShort();
        var addedPlayers_ = new DungeonPartyFinderPlayer[addedPlayersCount];

        for (var addedPlayersIndex = 0; addedPlayersIndex < addedPlayersCount; addedPlayersIndex++)
        {
            var objectToAdd = new DungeonPartyFinderPlayer();
            objectToAdd.Deserialize(reader);
            addedPlayers_[addedPlayersIndex] = objectToAdd;
        }
        AddedPlayers = addedPlayers_;
        ushort removedPlayersIdsCount = reader.ReadUShort();
        var removedPlayersIds_ = new ulong[removedPlayersIdsCount];

        for (var removedPlayersIdsIndex = 0; removedPlayersIdsIndex < removedPlayersIdsCount; removedPlayersIdsIndex++)
            removedPlayersIds_[removedPlayersIdsIndex] = reader.ReadVarULong();
        RemovedPlayersIds = removedPlayersIds_;
    }
}