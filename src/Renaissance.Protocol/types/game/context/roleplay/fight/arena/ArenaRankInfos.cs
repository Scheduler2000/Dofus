//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 08/12/2019 12:51:02.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
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

		public  Memory<byte> Serialize()
		{

			int size = default;

			var serialized1 = this.Ranking.Serialize();
			size += serialized1.Length;
			var serialized2 = this.LeagueRanking.Serialize();
			size += serialized2.Length;
			size += DofusBinaryFactory.Sizing.SizeOf(VictoryCount);
			size += DofusBinaryFactory.Sizing.SizeOf(Fightcount);
			size += DofusBinaryFactory.Sizing.SizeOf(NumFightNeededForLadder);


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteDatas(serialized1);
			writer.WriteDatas(serialized2);
			writer.WriteData(this.VictoryCount);
			writer.WriteData(this.Fightcount);
			writer.WriteData(this.NumFightNeededForLadder);

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
