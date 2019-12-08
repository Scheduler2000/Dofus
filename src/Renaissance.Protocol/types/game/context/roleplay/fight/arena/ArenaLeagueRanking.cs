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
	public class ArenaLeagueRanking : IDofusType
	{
		public  const int NetworkId = 553;
		public  int ProtocolId { get { return NetworkId; } }

		public CustomVar<short> Rank { get; set; }

		public CustomVar<short> LeagueId { get; set; }

		public CustomVar<short> LeaguePoints { get; set; }

		public CustomVar<short> TotalLeaguePoints { get; set; }

		public int LadderPosition { get; set; }


		public ArenaLeagueRanking() { }


		public ArenaLeagueRanking InitArenaLeagueRanking(CustomVar<short> _rank, CustomVar<short> _leagueid, CustomVar<short> _leaguepoints, CustomVar<short> _totalleaguepoints, int _ladderposition)
		{

			this.Rank = _rank;
			this.LeagueId = _leagueid;
			this.LeaguePoints = _leaguepoints;
			this.TotalLeaguePoints = _totalleaguepoints;
			this.LadderPosition = _ladderposition;

			return this;
		}

		public  Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(Rank);
			size += DofusBinaryFactory.Sizing.SizeOf(LeagueId);
			size += DofusBinaryFactory.Sizing.SizeOf(LeaguePoints);
			size += DofusBinaryFactory.Sizing.SizeOf(TotalLeaguePoints);
			size += DofusBinaryFactory.Sizing.SizeOf(LadderPosition);


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteData(this.Rank);
			writer.WriteData(this.LeagueId);
			writer.WriteData(this.LeaguePoints);
			writer.WriteData(this.TotalLeaguePoints);
			writer.WriteData(this.LadderPosition);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.Rank = reader.Read<CustomVar<short>>();
			this.LeagueId = reader.Read<CustomVar<short>>();
			this.LeaguePoints = reader.Read<CustomVar<short>>();
			this.TotalLeaguePoints = reader.Read<CustomVar<short>>();
			this.LadderPosition = reader.Read<int>();

		}


	}
}
