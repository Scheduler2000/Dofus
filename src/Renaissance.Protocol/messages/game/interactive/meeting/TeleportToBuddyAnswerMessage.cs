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
	public class TeleportToBuddyAnswerMessage : IDofusMessage
	{
		public  const int NetworkId = 6293;
		public  int ProtocolId { get { return NetworkId; } }

		public CustomVar<short> DungeonId { get; set; }

		public CustomVar<long> BuddyId { get; set; }

		public bool Accept { get; set; }


		public TeleportToBuddyAnswerMessage() { }


		public TeleportToBuddyAnswerMessage InitTeleportToBuddyAnswerMessage(CustomVar<short> _dungeonid, CustomVar<long> _buddyid, bool _accept)
		{

			this.DungeonId = _dungeonid;
			this.BuddyId = _buddyid;
			this.Accept = _accept;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(this.DungeonId);
			writer.Write(this.BuddyId);
			writer.Write(this.Accept);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.DungeonId = reader.Read<CustomVar<short>>();
			this.BuddyId = reader.Read<CustomVar<long>>();
			this.Accept = reader.Read<bool>();

		}


	}
}