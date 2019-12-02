//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:26.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.messages.game.context.roleplay.quest
{
	public class FollowQuestObjectiveRequestMessage : IDofusMessage
	{
		public  const int NetworkId = 6724;
		public  int ProtocolId { get { return NetworkId; } }

		public CustomVar<short> QuestId { get; set; }

		public short ObjectiveId { get; set; }


		public FollowQuestObjectiveRequestMessage() { }


		public FollowQuestObjectiveRequestMessage InitFollowQuestObjectiveRequestMessage(CustomVar<short> _questid, short _objectiveid)
		{

			this.QuestId = _questid;
			this.ObjectiveId = _objectiveid;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(this.QuestId);
			writer.Write(this.ObjectiveId);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.QuestId = reader.Read<CustomVar<short>>();
			this.ObjectiveId = reader.Read<short>();

		}


	}
}
