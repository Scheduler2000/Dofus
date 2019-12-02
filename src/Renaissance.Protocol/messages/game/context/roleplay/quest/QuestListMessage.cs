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
using    Renaissance.Protocol.types.game.context.roleplay.quest;

namespace Renaissance.Protocol.messages.game.context.roleplay.quest
{
	public class QuestListMessage : IDofusMessage
	{
		public  const int NetworkId = 5626;
		public  int ProtocolId { get { return NetworkId; } }

		public CustomVar<short>[] FinishedQuestsIds { get; set; }

		public CustomVar<short>[] FinishedQuestsCounts { get; set; }

		public QuestActiveInformations[] ActiveQuests { get; set; }

		public CustomVar<short>[] ReinitDoneQuestsIds { get; set; }


		public QuestListMessage() { }


		public QuestListMessage InitQuestListMessage(CustomVar<short>[] _finishedquestsids, CustomVar<short>[] _finishedquestscounts, QuestActiveInformations[] _activequests, CustomVar<short>[] _reinitdonequestsids)
		{

			this.FinishedQuestsIds = _finishedquestsids;
			this.FinishedQuestsCounts = _finishedquestscounts;
			this.ActiveQuests = _activequests;
			this.ReinitDoneQuestsIds = _reinitdonequestsids;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write((short)(this.FinishedQuestsIds.Length));
			foreach(var item in FinishedQuestsIds)
				writer.Write(item);
			writer.Write((short)(this.FinishedQuestsCounts.Length));
			foreach(var item in FinishedQuestsCounts)
				writer.Write(item);
			writer.Write((short)(this.ActiveQuests.Length));
			foreach(var obj in ActiveQuests)
			{
				writer.Write((short)(obj.ProtocolId));
				writer.Write(obj.Serialize());
			}
			writer.Write((short)(this.ReinitDoneQuestsIds.Length));
			foreach(var item in ReinitDoneQuestsIds)
				writer.Write(item);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			int FinishedQuestsIds_length = reader.Read<short>();
			this.FinishedQuestsIds = new CustomVar<short>[FinishedQuestsIds_length];
			for(int i = 0; i < FinishedQuestsIds_length; i++)
				this.FinishedQuestsIds[i] = reader.Read<CustomVar<short>>();
			int FinishedQuestsCounts_length = reader.Read<short>();
			this.FinishedQuestsCounts = new CustomVar<short>[FinishedQuestsCounts_length];
			for(int i = 0; i < FinishedQuestsCounts_length; i++)
				this.FinishedQuestsCounts[i] = reader.Read<CustomVar<short>>();
			int ActiveQuests_length = reader.Read<short>();
			this.ActiveQuests = new QuestActiveInformations[ActiveQuests_length];
			for(int i = 0; i < ActiveQuests_length; i++)
			{
reader.Skip(2); // skip read short for protocolManager.GetInstance(short)
				this.ActiveQuests[i] = new QuestActiveInformations();
				this.ActiveQuests[i].Deserialize(reader);
			}
			int ReinitDoneQuestsIds_length = reader.Read<short>();
			this.ReinitDoneQuestsIds = new CustomVar<short>[ReinitDoneQuestsIds_length];
			for(int i = 0; i < ReinitDoneQuestsIds_length; i++)
				this.ReinitDoneQuestsIds[i] = reader.Read<CustomVar<short>>();

		}


	}
}
