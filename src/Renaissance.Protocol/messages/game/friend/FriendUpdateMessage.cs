//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:11.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    Renaissance.Binary;
using    Renaissance.Binary.Definition;
using    Renaissance.Protocol.types.game.friend;

namespace Renaissance.Protocol.messages.game.friend
{
	public class FriendUpdateMessage : IDofusMessage
	{
		public  const int NetworkId = 5924;
		public  int ProtocolId { get { return NetworkId; } }

		public FriendInformations FriendUpdated { get; set; }


		public FriendUpdateMessage() { }


		public FriendUpdateMessage InitFriendUpdateMessage(FriendInformations _friendupdated)
		{

			this.FriendUpdated = _friendupdated;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write((short)(FriendUpdated.ProtocolId));
			writer.Write(this.FriendUpdated.Serialize());

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

reader.Skip(2); // skip read short
			this.FriendUpdated = new FriendInformations();
			this.FriendUpdated.Deserialize(reader);

		}


	}
}
