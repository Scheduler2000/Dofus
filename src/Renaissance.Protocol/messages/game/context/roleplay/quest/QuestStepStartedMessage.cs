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
	public class QuestStepStartedMessage : IDofusMessage
	{
		public  const int NetworkId = 6096;
		public  int ProtocolId { get { return NetworkId; } }

		public CustomVar<short> QuestId { get; set; }

		public CustomVar<short> StepId { get; set; }


		public QuestStepStartedMessage() { }


		public QuestStepStartedMessage InitQuestStepStartedMessage(CustomVar<short> _questid, CustomVar<short> _stepid)
		{

			this.QuestId = _questid;
			this.StepId = _stepid;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(this.QuestId);
			writer.Write(this.StepId);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.QuestId = reader.Read<CustomVar<short>>();
			this.StepId = reader.Read<CustomVar<short>>();

		}


	}
}
