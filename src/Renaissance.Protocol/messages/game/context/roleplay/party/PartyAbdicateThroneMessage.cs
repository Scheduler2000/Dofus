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
	public class PartyAbdicateThroneMessage : AbstractPartyMessage, IDofusMessage
	{
		public new const int NetworkId = 6080;
		public new int ProtocolId { get { return NetworkId; } }

		public CustomVar<long> PlayerId { get; set; }


		public PartyAbdicateThroneMessage() { }


		public PartyAbdicateThroneMessage InitPartyAbdicateThroneMessage(CustomVar<long> _playerid)
		{

			this.PlayerId = _playerid;

			return this;
		}

		public new byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(base.Serialize());
			writer.Write(this.PlayerId);

			return writer.Data;
		}

		public new void Deserialize(DofusReader reader)
		{

			base.Deserialize(reader);
			this.PlayerId = reader.Read<CustomVar<long>>();

		}


	}
}
