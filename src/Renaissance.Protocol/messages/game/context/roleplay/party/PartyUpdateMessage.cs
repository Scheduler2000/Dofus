//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 08/12/2019 12:50:56.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
using    Renaissance.Binary;
using    Renaissance.Binary.Definition;
using    Renaissance.Protocol.types.game.context.roleplay.party;

namespace Renaissance.Protocol.messages.game.context.roleplay.party
{
	public class PartyUpdateMessage : AbstractPartyEventMessage, IDofusMessage
	{
		public new const int NetworkId = 5575;
		public new int ProtocolId { get { return NetworkId; } }

		public PartyMemberInformations MemberInformations { get; set; }


		public PartyUpdateMessage() { }


		public PartyUpdateMessage InitPartyUpdateMessage(CustomVar<int> _partyid, PartyMemberInformations _memberinformations)
		{

			base.PartyId = _partyid;
			this.MemberInformations = _memberinformations;

			return this;
		}

		public new Memory<byte> Serialize()
		{

			int size = default;

			size += 2;
			var serialized1 = this.MemberInformations.Serialize();
			size += serialized1.Length;
			var parent = base.Serialize();
			size += parent.Length;


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteDatas(parent);
			writer.WriteData((short)(MemberInformations.ProtocolId));
			writer.WriteDatas(serialized1);

			return writer.Data;
		}

		public new void Deserialize(DofusReader reader)
		{

			base.Deserialize(reader);
			reader.Skip(2); // skip protocolManager.GetInstance(short)
			this.MemberInformations = new PartyMemberInformations();
			this.MemberInformations.Deserialize(reader);

		}


	}
}
