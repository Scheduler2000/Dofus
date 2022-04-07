using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class ArenaRankInfos
{
    public const short Id = 750;

    public ArenaRankInfos(ArenaRanking ranking,
        ArenaLeagueRanking leagueRanking,
        ushort victoryCount,
        ushort fightcount,
        short numFightNeededForLadder)
    {
        Ranking = ranking;
        LeagueRanking = leagueRanking;
        VictoryCount = victoryCount;
        Fightcount = fightcount;
        NumFightNeededForLadder = numFightNeededForLadder;
    }

    public ArenaRankInfos()
    {
    }

    public virtual short TypeId => Id;

    public ArenaRanking Ranking { get; set; }

    public ArenaLeagueRanking LeagueRanking { get; set; }

    public ushort VictoryCount { get; set; }

    public ushort Fightcount { get; set; }

    public short NumFightNeededForLadder { get; set; }

    public virtual void Serialize(IDataWriter writer)
    {
        if (Ranking == null) { writer.WriteByte(0); }
        else
        {
            writer.WriteByte(1);
            Ranking.Serialize(writer);
        }

        if (LeagueRanking == null) { writer.WriteByte(0); }
        else
        {
            writer.WriteByte(1);
            LeagueRanking.Serialize(writer);
        }

        writer.WriteVarUShort(VictoryCount);
        writer.WriteVarUShort(Fightcount);
        writer.WriteShort(NumFightNeededForLadder);
    }

    public virtual void Deserialize(IDataReader reader)
    {
        if (reader.ReadByte() == 0) { Ranking = null; }
        else
        {
            Ranking = new ArenaRanking();
            Ranking.Deserialize(reader);
        }

        if (reader.ReadByte() == 0) { LeagueRanking = null; }
        else
        {
            LeagueRanking = new ArenaLeagueRanking();
            LeagueRanking.Deserialize(reader);
        }

        VictoryCount = reader.ReadVarUShort();
        Fightcount = reader.ReadVarUShort();
        NumFightNeededForLadder = reader.ReadShort();
    }
}