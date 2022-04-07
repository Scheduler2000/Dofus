using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class ArenaLeagueRanking
{
    public const short Id = 2820;

    public ArenaLeagueRanking(ushort rank, ushort leagueId, short leaguePoints, short totalLeaguePoints, int ladderPosition)
    {
        Rank = rank;
        LeagueId = leagueId;
        LeaguePoints = leaguePoints;
        TotalLeaguePoints = totalLeaguePoints;
        LadderPosition = ladderPosition;
    }

    public ArenaLeagueRanking()
    {
    }

    public virtual short TypeId => Id;

    public ushort Rank { get; set; }

    public ushort LeagueId { get; set; }

    public short LeaguePoints { get; set; }

    public short TotalLeaguePoints { get; set; }

    public int LadderPosition { get; set; }

    public virtual void Serialize(IDataWriter writer)
    {
        writer.WriteVarUShort(Rank);
        writer.WriteVarUShort(LeagueId);
        writer.WriteVarShort(LeaguePoints);
        writer.WriteVarShort(TotalLeaguePoints);
        writer.WriteInt(LadderPosition);
    }

    public virtual void Deserialize(IDataReader reader)
    {
        Rank = reader.ReadVarUShort();
        LeagueId = reader.ReadVarUShort();
        LeaguePoints = reader.ReadVarShort();
        TotalLeaguePoints = reader.ReadVarShort();
        LadderPosition = reader.ReadInt();
    }
}