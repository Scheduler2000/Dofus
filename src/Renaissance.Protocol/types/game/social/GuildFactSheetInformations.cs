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
using    Renaissance.Protocol.types.game.context.roleplay;
using    Renaissance.Protocol.types.game.guild;

namespace Renaissance.Protocol.types.game.social
{
	public class GuildFactSheetInformations : GuildInformations, IDofusType
	{
		public new const int NetworkId = 424;
		public new int ProtocolId { get { return NetworkId; } }

		public CustomVar<long> LeaderId { get; set; }

		public CustomVar<short> NbMembers { get; set; }


		public GuildFactSheetInformations() { }


		public GuildFactSheetInformations InitGuildFactSheetInformations(CustomVar<long> _leaderid, CustomVar<short> _nbmembers)
		{

			this.LeaderId = _leaderid;
			this.NbMembers = _nbmembers;

			return this;
		}

		public new byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(base.Serialize());
			writer.Write(this.LeaderId);
			writer.Write(this.NbMembers);

			return writer.Data;
		}

		public new void Deserialize(DofusReader reader)
		{

			base.Deserialize(reader);
			this.LeaderId = reader.Read<CustomVar<long>>();
			this.NbMembers = reader.Read<CustomVar<short>>();

		}


	}
}
