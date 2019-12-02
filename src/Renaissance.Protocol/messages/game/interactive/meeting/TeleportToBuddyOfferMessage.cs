//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:19.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.messages.game.interactive.meeting
{
	public class TeleportToBuddyOfferMessage : IDofusMessage
	{
		public  const int NetworkId = 6287;
		public  int ProtocolId { get { return NetworkId; } }

		public CustomVar<short> DungeonId { get; set; }

		public CustomVar<long> BuddyId { get; set; }

		public CustomVar<int> TimeLeft { get; set; }


		public TeleportToBuddyOfferMessage() { }


		public TeleportToBuddyOfferMessage InitTeleportToBuddyOfferMessage(CustomVar<short> _dungeonid, CustomVar<long> _buddyid, CustomVar<int> _timeleft)
		{

			this.DungeonId = _dungeonid;
			this.BuddyId = _buddyid;
			this.TimeLeft = _timeleft;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(this.DungeonId);
			writer.Write(this.BuddyId);
			writer.Write(this.TimeLeft);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.DungeonId = reader.Read<CustomVar<short>>();
			this.BuddyId = reader.Read<CustomVar<long>>();
			this.TimeLeft = reader.Read<CustomVar<int>>();

		}


	}
}