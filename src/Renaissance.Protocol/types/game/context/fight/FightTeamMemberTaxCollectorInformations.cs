//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 08/12/2019 12:51:00.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.types.game.context.fight
{
	public class FightTeamMemberTaxCollectorInformations : FightTeamMemberInformations, IDofusType
	{
		public new const int NetworkId = 177;
		public new int ProtocolId { get { return NetworkId; } }

		public CustomVar<short> FirstNameId { get; set; }

		public CustomVar<short> LastNameId { get; set; }

		public byte Level { get; set; }

		public CustomVar<int> GuildId { get; set; }

		public double Uid { get; set; }


		public FightTeamMemberTaxCollectorInformations() { }


		public FightTeamMemberTaxCollectorInformations InitFightTeamMemberTaxCollectorInformations(double _id, CustomVar<short> _firstnameid, CustomVar<short> _lastnameid, byte _level, CustomVar<int> _guildid, double _uid)
		{

			base.Id = _id;
			this.FirstNameId = _firstnameid;
			this.LastNameId = _lastnameid;
			this.Level = _level;
			this.GuildId = _guildid;
			this.Uid = _uid;

			return this;
		}

		public new Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(FirstNameId);
			size += DofusBinaryFactory.Sizing.SizeOf(LastNameId);
			size += DofusBinaryFactory.Sizing.SizeOf(Level);
			size += DofusBinaryFactory.Sizing.SizeOf(GuildId);
			size += DofusBinaryFactory.Sizing.SizeOf(Uid);
			var parent = base.Serialize();
			size += parent.Length;


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteDatas(parent);
			writer.WriteData(this.FirstNameId);
			writer.WriteData(this.LastNameId);
			writer.WriteData(this.Level);
			writer.WriteData(this.GuildId);
			writer.WriteData(this.Uid);

			return writer.Data;
		}

		public new void Deserialize(DofusReader reader)
		{

			base.Deserialize(reader);
			this.FirstNameId = reader.Read<CustomVar<short>>();
			this.LastNameId = reader.Read<CustomVar<short>>();
			this.Level = reader.Read<byte>();
			this.GuildId = reader.Read<CustomVar<int>>();
			this.Uid = reader.Read<double>();

		}


	}
}
