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
using    Renaissance.Protocol.types.game.context.roleplay;

namespace Renaissance.Protocol.types.game.context.fight
{
	public class FightTeamMemberWithAllianceCharacterInformations : FightTeamMemberCharacterInformations, IDofusType
	{
		public new const int NetworkId = 426;
		public new int ProtocolId { get { return NetworkId; } }

		public BasicAllianceInformations AllianceInfos { get; set; }


		public FightTeamMemberWithAllianceCharacterInformations() { }


		public FightTeamMemberWithAllianceCharacterInformations InitFightTeamMemberWithAllianceCharacterInformations(string _name, CustomVar<short> _level, double _id, BasicAllianceInformations _allianceinfos)
		{

			base.Name = _name;
			base.Level = _level;
			base.Id = _id;
			this.AllianceInfos = _allianceinfos;

			return this;
		}

		public new Memory<byte> Serialize()
		{

			int size = default;

			var serialized1 = this.AllianceInfos.Serialize();
			size += serialized1.Length;
			var parent = base.Serialize();
			size += parent.Length;


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteDatas(parent);
			writer.WriteDatas(serialized1);

			return writer.Data;
		}

		public new void Deserialize(DofusReader reader)
		{

			base.Deserialize(reader);
			this.AllianceInfos = new BasicAllianceInformations();
			this.AllianceInfos.Deserialize(reader);

		}


	}
}
