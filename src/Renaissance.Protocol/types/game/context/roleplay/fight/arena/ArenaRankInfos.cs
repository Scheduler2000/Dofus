//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:32.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.types.game.context.roleplay.fight.arena
{
	public class ArenaRankInfos : IDofusType
	{
		public  const int NetworkId = 499;
		public  int ProtocolId { get { return NetworkId; } }

		public ArenaRanking Ranking { get; set; }

		public ArenaLeagueRanking LeagueRanking { get; set; }

		public CustomVar<short> VictoryCount { get; set; }

		public CustomVar<short> Fightcount { get; set; }

		public short NumFightNeededForLadder { get; set; }


		public ArenaRankInfos() { }


		public ArenaRankInfos InitArenaRankInfos(ArenaRanking _ranking, ArenaLeagueRanking _leagueranking, CustomVar<short> _victorycount, CustomVar<short> _fightcount, short _numfightneededforladder)
		{

			this.Ranking = _ranking;
			this.LeagueRanking = _leagueranking;
			this.VictoryCount = _victorycount;
			this.Fightcount = _fightcount;
			this.NumFightNeededForLadder = _numfightneededforladder;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(this.Ranking.Serialize());
			writer.Write(this.LeagueRanking.Serialize());
			writer.Write(this.VictoryCount);
			writer.Write(this.Fightcount);
			writer.Write(this.NumFightNeededForLadder);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.Ranking = new ArenaRanking();
			this.Ranking.Deserialize(reader);
			this.LeagueRanking = new ArenaLeagueRanking();
			this.LeagueRanking.Deserialize(reader);
			this.VictoryCount = reader.Read<CustomVar<short>>();
			this.Fightcount = reader.Read<CustomVar<short>>();
			this.NumFightNeededForLadder = reader.Read<short>();

		}


	}
}