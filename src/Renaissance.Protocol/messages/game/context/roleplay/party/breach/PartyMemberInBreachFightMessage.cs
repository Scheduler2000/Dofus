//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 08/12/2019 12:50:57.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
using    Renaissance.Binary;
using    Renaissance.Binary.Definition;
using    Renaissance.Protocol.messages.game.context.roleplay.party;

namespace Renaissance.Protocol.messages.game.context.roleplay.party.breach
{
	public class PartyMemberInBreachFightMessage : AbstractPartyMemberInFightMessage, IDofusMessage
	{
		public new const int NetworkId = 6824;
		public new int ProtocolId { get { return NetworkId; } }

		public CustomVar<int> Floor { get; set; }

		public byte Room { get; set; }


		public PartyMemberInBreachFightMessage() { }


		public PartyMemberInBreachFightMessage InitPartyMemberInBreachFightMessage(byte _reason, CustomVar<long> _memberid, int _memberaccountid, string _membername, CustomVar<short> _fightid, CustomVar<short> _timebeforefightstart, CustomVar<int> _partyid, CustomVar<int> _floor, byte _room)
		{

			base.Reason = _reason;
			base.MemberId = _memberid;
			base.MemberAccountId = _memberaccountid;
			base.MemberName = _membername;
			base.FightId = _fightid;
			base.TimeBeforeFightStart = _timebeforefightstart;
			base.PartyId = _partyid;
			this.Floor = _floor;
			this.Room = _room;

			return this;
		}

		public new Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(Floor);
			size += DofusBinaryFactory.Sizing.SizeOf(Room);
			var parent = base.Serialize();
			size += parent.Length;


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteDatas(parent);
			writer.WriteData(this.Floor);
			writer.WriteData(this.Room);

			return writer.Data;
		}

		public new void Deserialize(DofusReader reader)
		{

			base.Deserialize(reader);
			this.Floor = reader.Read<CustomVar<int>>();
			this.Room = reader.Read<byte>();

		}


	}
}
