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
	public class TreasureHuntGiveUpRequestMessage : IDofusMessage
	{
		public  const int NetworkId = 6487;
		public  int ProtocolId { get { return NetworkId; } }

		public byte QuestType { get; set; }


		public TreasureHuntGiveUpRequestMessage() { }


		public TreasureHuntGiveUpRequestMessage InitTreasureHuntGiveUpRequestMessage(byte _questtype)
		{

			this.QuestType = _questtype;

			return this;
		}

		public  Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(QuestType);


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteData(this.QuestType);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.QuestType = reader.Read<byte>();

		}


	}
}
