//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 08/12/2019 12:50:55.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.messages.game.context.roleplay.party
{
	public class PartyLeaderUpdateMessage : AbstractPartyEventMessage, IDofusMessage
	{
		public new const int NetworkId = 5578;
		public new int ProtocolId { get { return NetworkId; } }

		public CustomVar<long> PartyLeaderId { get; set; }


		public PartyLeaderUpdateMessage() { }


		public PartyLeaderUpdateMessage InitPartyLeaderUpdateMessage(CustomVar<int> _partyid, CustomVar<long> _partyleaderid)
		{

			base.PartyId = _partyid;
			this.PartyLeaderId = _partyleaderid;

			return this;
		}

		public new Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(PartyLeaderId);
			var parent = base.Serialize();
			size += parent.Length;


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteDatas(parent);
			writer.WriteData(this.PartyLeaderId);

			return writer.Data;
		}

		public new void Deserialize(DofusReader reader)
		{

			base.Deserialize(reader);
			this.PartyLeaderId = reader.Read<CustomVar<long>>();

		}


	}
}
