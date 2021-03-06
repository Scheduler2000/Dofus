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
	public class QuestStartRequestMessage : IDofusMessage
	{
		public  const int NetworkId = 5643;
		public  int ProtocolId { get { return NetworkId; } }

		public CustomVar<short> QuestId { get; set; }


		public QuestStartRequestMessage() { }


		public QuestStartRequestMessage InitQuestStartRequestMessage(CustomVar<short> _questid)
		{

			this.QuestId = _questid;

			return this;
		}

		public  Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(QuestId);


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteData(this.QuestId);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.QuestId = reader.Read<CustomVar<short>>();

		}


	}
}
