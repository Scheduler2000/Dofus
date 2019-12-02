//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:08.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    Renaissance.Binary;
using    Renaissance.Binary.Definition;
using    Renaissance.Protocol.types.game.context.roleplay;

namespace Renaissance.Protocol.messages.game.alliance
{
	public class AllianceJoinedMessage : IDofusMessage
	{
		public  const int NetworkId = 6402;
		public  int ProtocolId { get { return NetworkId; } }

		public AllianceInformations AllianceInfo { get; set; }

		public bool Enabled { get; set; }

		public CustomVar<int> LeadingGuildId { get; set; }


		public AllianceJoinedMessage() { }


		public AllianceJoinedMessage InitAllianceJoinedMessage(AllianceInformations _allianceinfo, bool _enabled, CustomVar<int> _leadingguildid)
		{

			this.AllianceInfo = _allianceinfo;
			this.Enabled = _enabled;
			this.LeadingGuildId = _leadingguildid;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(this.AllianceInfo.Serialize());
			writer.Write(this.Enabled);
			writer.Write(this.LeadingGuildId);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.AllianceInfo = new AllianceInformations();
			this.AllianceInfo.Deserialize(reader);
			this.Enabled = reader.Read<bool>();
			this.LeadingGuildId = reader.Read<CustomVar<int>>();

		}


	}
}
