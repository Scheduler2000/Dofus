//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:08.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.messages.game.achievement
{
	public class FriendGuildSetWarnOnAchievementCompleteMessage : IDofusMessage
	{
		public  const int NetworkId = 6382;
		public  int ProtocolId { get { return NetworkId; } }

		public bool Enable { get; set; }


		public FriendGuildSetWarnOnAchievementCompleteMessage() { }


		public FriendGuildSetWarnOnAchievementCompleteMessage InitFriendGuildSetWarnOnAchievementCompleteMessage(bool _enable)
		{

			this.Enable = _enable;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(this.Enable);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.Enable = reader.Read<bool>();

		}


	}
}