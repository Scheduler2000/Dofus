//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:29.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

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


		public FightTeamMemberTaxCollectorInformations InitFightTeamMemberTaxCollectorInformations(CustomVar<short> _firstnameid, CustomVar<short> _lastnameid, byte _level, CustomVar<int> _guildid, double _uid)
		{

			this.FirstNameId = _firstnameid;
			this.LastNameId = _lastnameid;
			this.Level = _level;
			this.GuildId = _guildid;
			this.Uid = _uid;

			return this;
		}

		public new byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(base.Serialize());
			writer.Write(this.FirstNameId);
			writer.Write(this.LastNameId);
			writer.Write(this.Level);
			writer.Write(this.GuildId);
			writer.Write(this.Uid);

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