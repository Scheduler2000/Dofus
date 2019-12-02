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

namespace Renaissance.Protocol.messages.game.context.roleplay.treasureHunt
{
	public class TreasureHuntFlagRequestAnswerMessage : IDofusMessage
	{
		public  const int NetworkId = 6507;
		public  int ProtocolId { get { return NetworkId; } }

		public byte QuestType { get; set; }

		public byte Result { get; set; }

		public byte Index { get; set; }


		public TreasureHuntFlagRequestAnswerMessage() { }


		public TreasureHuntFlagRequestAnswerMessage InitTreasureHuntFlagRequestAnswerMessage(byte _questtype, byte _result, byte _index)
		{

			this.QuestType = _questtype;
			this.Result = _result;
			this.Index = _index;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(this.QuestType);
			writer.Write(this.Result);
			writer.Write(this.Index);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.QuestType = reader.Read<byte>();
			this.Result = reader.Read<byte>();
			this.Index = reader.Read<byte>();

		}


	}
}