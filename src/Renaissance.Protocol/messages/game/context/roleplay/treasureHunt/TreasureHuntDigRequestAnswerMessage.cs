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

namespace Renaissance.Protocol.messages.game.context.roleplay.treasureHunt
{
	public class TreasureHuntDigRequestAnswerMessage : IDofusMessage
	{
		public  const int NetworkId = 6484;
		public  int ProtocolId { get { return NetworkId; } }

		public byte QuestType { get; set; }

		public byte Result { get; set; }


		public TreasureHuntDigRequestAnswerMessage() { }


		public TreasureHuntDigRequestAnswerMessage InitTreasureHuntDigRequestAnswerMessage(byte _questtype, byte _result)
		{

			this.QuestType = _questtype;
			this.Result = _result;

			return this;
		}

		public  Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(QuestType);
			size += DofusBinaryFactory.Sizing.SizeOf(Result);


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteData(this.QuestType);
			writer.WriteData(this.Result);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.QuestType = reader.Read<byte>();
			this.Result = reader.Read<byte>();

		}


	}
}
