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
	public class FightTeamLightInformations : AbstractFightTeamInformations, IDofusType
	{
		public new const int NetworkId = 115;
		public new int ProtocolId { get { return NetworkId; } }

		public byte TeamMembersCount { get; set; }

		public CustomVar<int> MeanLevel { get; set; }

		public WrappedBool HasFriend { get; set; }

		public WrappedBool HasGuildMember { get; set; }

		public WrappedBool HasAllianceMember { get; set; }

		public WrappedBool HasGroupMember { get; set; }

		public WrappedBool HasMyTaxCollector { get; set; }


		public FightTeamLightInformations() { }


		public FightTeamLightInformations InitFightTeamLightInformations(byte _teammemberscount, CustomVar<int> _meanlevel, WrappedBool _hasfriend, WrappedBool _hasguildmember, WrappedBool _hasalliancemember, WrappedBool _hasgroupmember, WrappedBool _hasmytaxcollector)
		{

			this.TeamMembersCount = _teammemberscount;
			this.MeanLevel = _meanlevel;
			this.HasFriend = _hasfriend;
			this.HasGuildMember = _hasguildmember;
			this.HasAllianceMember = _hasalliancemember;
			this.HasGroupMember = _hasgroupmember;
			this.HasMyTaxCollector = _hasmytaxcollector;

			return this;
		}

		public new byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(base.Serialize());
			byte box = 0;
			box = writer.SetFlag(box,0,this.HasFriend);
			box = writer.SetFlag(box,1,this.HasGuildMember);
			box = writer.SetFlag(box,2,this.HasAllianceMember);
			box = writer.SetFlag(box,3,this.HasGroupMember);
			box = writer.SetFlag(box,4,this.HasMyTaxCollector);
			writer.Write(box);
			writer.Write(this.TeamMembersCount);
			writer.Write(this.MeanLevel);

			return writer.Data;
		}

		public new void Deserialize(DofusReader reader)
		{

			base.Deserialize(reader);
			byte box = reader.Read<byte>();
			this.HasFriend = reader.ReadFlag(box,0);
			this.HasGuildMember = reader.ReadFlag(box,1);
			this.HasAllianceMember = reader.ReadFlag(box,2);
			this.HasGroupMember = reader.ReadFlag(box,3);
			this.HasMyTaxCollector = reader.ReadFlag(box,4);
			this.TeamMembersCount = reader.Read<byte>();
			this.MeanLevel = reader.Read<CustomVar<int>>();

		}


	}
}