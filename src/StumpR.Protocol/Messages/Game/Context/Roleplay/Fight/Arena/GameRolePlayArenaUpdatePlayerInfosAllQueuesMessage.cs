using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GameRolePlayArenaUpdatePlayerInfosAllQueuesMessage : GameRolePlayArenaUpdatePlayerInfosMessage
{
    public new const uint Id = 6540;

    public GameRolePlayArenaUpdatePlayerInfosAllQueuesMessage(ArenaRankInfos solo, ArenaRankInfos team, ArenaRankInfos duel)
    {
        Solo = solo;
        Team = team;
        Duel = duel;
    }

    public GameRolePlayArenaUpdatePlayerInfosAllQueuesMessage()
    {
    }

    public override uint MessageId => Id;

    public ArenaRankInfos Team { get; set; }

    public ArenaRankInfos Duel { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        Team.Serialize(writer);
        Duel.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        Team = new ArenaRankInfos();
        Team.Deserialize(reader);
        Duel = new ArenaRankInfos();
        Duel.Deserialize(reader);
    }
}