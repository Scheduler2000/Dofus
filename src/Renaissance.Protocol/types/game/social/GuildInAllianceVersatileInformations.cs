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

namespace Renaissance.Protocol.types.game.social
{
	public class GuildInAllianceVersatileInformations : GuildVersatileInformations, IDofusType
	{
		public new const int NetworkId = 437;
		public new int ProtocolId { get { return NetworkId; } }

		public CustomVar<int> AllianceId { get; set; }


		public GuildInAllianceVersatileInformations() { }


		public GuildInAllianceVersatileInformations InitGuildInAllianceVersatileInformations(CustomVar<int> _allianceid)
		{

			this.AllianceId = _allianceid;

			return this;
		}

		public new Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(AllianceId);
			var parent = base.Serialize();
			size += parent.Length;


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteDatas(parent);
			writer.WriteData(this.AllianceId);

			return writer.Data;
		}

		public new void Deserialize(DofusReader reader)
		{

			base.Deserialize(reader);
			this.AllianceId = reader.Read<CustomVar<int>>();

		}


	}
}
