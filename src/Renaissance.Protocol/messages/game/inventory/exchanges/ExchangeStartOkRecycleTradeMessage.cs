//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 08/12/2019 12:50:52.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.messages.game.inventory.exchanges
{
	public class ExchangeStartOkRecycleTradeMessage : IDofusMessage
	{
		public  const int NetworkId = 6600;
		public  int ProtocolId { get { return NetworkId; } }

		public short PercentToPrism { get; set; }

		public short PercentToPlayer { get; set; }


		public ExchangeStartOkRecycleTradeMessage() { }


		public ExchangeStartOkRecycleTradeMessage InitExchangeStartOkRecycleTradeMessage(short _percenttoprism, short _percenttoplayer)
		{

			this.PercentToPrism = _percenttoprism;
			this.PercentToPlayer = _percenttoplayer;

			return this;
		}

		public  Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(PercentToPrism);
			size += DofusBinaryFactory.Sizing.SizeOf(PercentToPlayer);


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteData(this.PercentToPrism);
			writer.WriteData(this.PercentToPlayer);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.PercentToPrism = reader.Read<short>();
			this.PercentToPlayer = reader.Read<short>();

		}


	}
}
