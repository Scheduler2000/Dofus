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
	public class TreasureHuntAvailableRetryCountUpdateMessage : IDofusMessage
	{
		public  const int NetworkId = 6491;
		public  int ProtocolId { get { return NetworkId; } }

		public byte QuestType { get; set; }

		public int AvailableRetryCount { get; set; }


		public TreasureHuntAvailableRetryCountUpdateMessage() { }


		public TreasureHuntAvailableRetryCountUpdateMessage InitTreasureHuntAvailableRetryCountUpdateMessage(byte _questtype, int _availableretrycount)
		{

			this.QuestType = _questtype;
			this.AvailableRetryCount = _availableretrycount;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(this.QuestType);
			writer.Write(this.AvailableRetryCount);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.QuestType = reader.Read<byte>();
			this.AvailableRetryCount = reader.Read<int>();

		}


	}
}