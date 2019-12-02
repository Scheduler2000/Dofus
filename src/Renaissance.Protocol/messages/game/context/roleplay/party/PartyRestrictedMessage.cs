//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:25.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.messages.game.context.roleplay.party
{
	public class PartyRestrictedMessage : AbstractPartyMessage, IDofusMessage
	{
		public new const int NetworkId = 6175;
		public new int ProtocolId { get { return NetworkId; } }

		public bool Restricted { get; set; }


		public PartyRestrictedMessage() { }


		public PartyRestrictedMessage InitPartyRestrictedMessage(bool _restricted)
		{

			this.Restricted = _restricted;

			return this;
		}

		public new byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(base.Serialize());
			writer.Write(this.Restricted);

			return writer.Data;
		}

		public new void Deserialize(DofusReader reader)
		{

			base.Deserialize(reader);
			this.Restricted = reader.Read<bool>();

		}


	}
}
