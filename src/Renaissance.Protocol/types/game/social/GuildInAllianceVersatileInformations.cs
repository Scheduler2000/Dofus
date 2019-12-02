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

		public new byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(base.Serialize());
			writer.Write(this.AllianceId);

			return writer.Data;
		}

		public new void Deserialize(DofusReader reader)
		{

			base.Deserialize(reader);
			this.AllianceId = reader.Read<CustomVar<int>>();

		}


	}
}
