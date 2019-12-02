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
	public class PartyNameUpdateMessage : AbstractPartyMessage, IDofusMessage
	{
		public new const int NetworkId = 6502;
		public new int ProtocolId { get { return NetworkId; } }

		public string PartyName { get; set; }


		public PartyNameUpdateMessage() { }


		public PartyNameUpdateMessage InitPartyNameUpdateMessage(string _partyname)
		{

			this.PartyName = _partyname;

			return this;
		}

		public new byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(base.Serialize());
			writer.Write(this.PartyName);

			return writer.Data;
		}

		public new void Deserialize(DofusReader reader)
		{

			base.Deserialize(reader);
			this.PartyName = reader.Read<string>();

		}


	}
}
