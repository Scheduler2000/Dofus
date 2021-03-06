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

namespace Renaissance.Protocol.messages.game.context.roleplay.quest
{
	public class QuestObjectiveValidationMessage : IDofusMessage
	{
		public  const int NetworkId = 6085;
		public  int ProtocolId { get { return NetworkId; } }

		public CustomVar<short> QuestId { get; set; }

		public CustomVar<short> ObjectiveId { get; set; }


		public QuestObjectiveValidationMessage() { }


		public QuestObjectiveValidationMessage InitQuestObjectiveValidationMessage(CustomVar<short> _questid, CustomVar<short> _objectiveid)
		{

			this.QuestId = _questid;
			this.ObjectiveId = _objectiveid;

			return this;
		}

		public  Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(QuestId);
			size += DofusBinaryFactory.Sizing.SizeOf(ObjectiveId);


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteData(this.QuestId);
			writer.WriteData(this.ObjectiveId);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.QuestId = reader.Read<CustomVar<short>>();
			this.ObjectiveId = reader.Read<CustomVar<short>>();

		}


	}
}
