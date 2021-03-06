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
	public class PartyKickRequestMessage : AbstractPartyMessage, IDofusMessage
	{
		public new const int NetworkId = 5592;
		public new int ProtocolId { get { return NetworkId; } }

		public CustomVar<long> PlayerId { get; set; }


		public PartyKickRequestMessage() { }


		public PartyKickRequestMessage InitPartyKickRequestMessage(CustomVar<int> _partyid, CustomVar<long> _playerid)
		{

			base.PartyId = _partyid;
			this.PlayerId = _playerid;

			return this;
		}

		public new Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(PlayerId);
			var parent = base.Serialize();
			size += parent.Length;


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteDatas(parent);
			writer.WriteData(this.PlayerId);

			return writer.Data;
		}

		public new void Deserialize(DofusReader reader)
		{

			base.Deserialize(reader);
			this.PlayerId = reader.Read<CustomVar<long>>();

		}


	}
}
