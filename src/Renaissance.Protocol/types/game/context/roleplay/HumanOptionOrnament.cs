//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 08/12/2019 12:51:01.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.types.game.context.roleplay
{
	public class HumanOptionOrnament : HumanOption, IDofusType
	{
		public new const int NetworkId = 411;
		public new int ProtocolId { get { return NetworkId; } }

		public CustomVar<short> OrnamentId { get; set; }

		public CustomVar<short> Level { get; set; }

		public CustomVar<short> LeagueId { get; set; }

		public int LadderPosition { get; set; }


		public HumanOptionOrnament() { }


		public HumanOptionOrnament InitHumanOptionOrnament(CustomVar<short> _ornamentid, CustomVar<short> _level, CustomVar<short> _leagueid, int _ladderposition)
		{

			this.OrnamentId = _ornamentid;
			this.Level = _level;
			this.LeagueId = _leagueid;
			this.LadderPosition = _ladderposition;

			return this;
		}

		public new Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(OrnamentId);
			size += DofusBinaryFactory.Sizing.SizeOf(Level);
			size += DofusBinaryFactory.Sizing.SizeOf(LeagueId);
			size += DofusBinaryFactory.Sizing.SizeOf(LadderPosition);
			var parent = base.Serialize();
			size += parent.Length;


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteDatas(parent);
			writer.WriteData(this.OrnamentId);
			writer.WriteData(this.Level);
			writer.WriteData(this.LeagueId);
			writer.WriteData(this.LadderPosition);

			return writer.Data;
		}

		public new void Deserialize(DofusReader reader)
		{

			base.Deserialize(reader);
			this.OrnamentId = reader.Read<CustomVar<short>>();
			this.Level = reader.Read<CustomVar<short>>();
			this.LeagueId = reader.Read<CustomVar<short>>();
			this.LadderPosition = reader.Read<int>();

		}


	}
}
