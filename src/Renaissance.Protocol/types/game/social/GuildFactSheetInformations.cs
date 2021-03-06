//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 08/12/2019 12:50:59.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
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

		public new Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(LeaderId);
			size += DofusBinaryFactory.Sizing.SizeOf(NbMembers);
			var parent = base.Serialize();
			size += parent.Length;


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteDatas(parent);
			writer.WriteData(this.LeaderId);
			writer.WriteData(this.NbMembers);

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
