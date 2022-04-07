using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GameRolePlayArenaLeagueRewardsMessage : Message
{
    public const uint Id = 2090;

    public GameRolePlayArenaLeagueRewardsMessage(ushort seasonId, ushort leagueId, int ladderPosition, bool endSeasonReward)
    {
        SeasonId = seasonId;
        LeagueId = leagueId;
        LadderPosition = ladderPosition;
        EndSeasonReward = endSeasonReward;
    }

    public GameRolePlayArenaLeagueRewardsMessage()
    {
    }

    public override uint MessageId => Id;

    public ushort SeasonId { get; set; }

    public ushort LeagueId { get; set; }

    public int LadderPosition { get; set; }

    public bool EndSeasonReward { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarUShort(SeasonId);
        writer.WriteVarUShort(LeagueId);
        writer.WriteInt(LadderPosition);
        writer.WriteBoolean(EndSeasonReward);
    }

    public override void Deserialize(IDataReader reader)
    {
        SeasonId = reader.ReadVarUShort();
        LeagueId = reader.ReadVarUShort();
        LadderPosition = reader.ReadInt();
        EndSeasonReward = reader.ReadBoolean();
    }
}