using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class DungeonPartyFinderRoomContentMessage : Message
{
    public const uint Id = 5100;

    public DungeonPartyFinderRoomContentMessage(ushort dungeonId, IEnumerable<DungeonPartyFinderPlayer> players)
    {
        DungeonId = dungeonId;
        Players = players;
    }

    public DungeonPartyFinderRoomContentMessage()
    {
    }

    public override uint MessageId => Id;

    public ushort DungeonId { get; set; }

    public IEnumerable<DungeonPartyFinderPlayer> Players { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarUShort(DungeonId);
        writer.WriteShort((short) Players.Count());
        foreach (DungeonPartyFinderPlayer objectToSend in Players) objectToSend.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        DungeonId = reader.ReadVarUShort();
        ushort playersCount = reader.ReadUShort();
        var players_ = new DungeonPartyFinderPlayer[playersCount];

        for (var playersIndex = 0; playersIndex < playersCount; playersIndex++)
        {
            var objectToAdd = new DungeonPartyFinderPlayer();
            objectToAdd.Deserialize(reader);
            players_[playersIndex] = objectToAdd;
        }
        Players = players_;
    }
}