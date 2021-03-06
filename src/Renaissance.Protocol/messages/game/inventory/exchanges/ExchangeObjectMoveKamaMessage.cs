//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 08/12/2019 12:50:51.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.messages.game.inventory.exchanges
{
	public class ExchangeObjectMoveKamaMessage : IDofusMessage
	{
		public  const int NetworkId = 5520;
		public  int ProtocolId { get { return NetworkId; } }

		public CustomVar<long> Quantity { get; set; }


		public ExchangeObjectMoveKamaMessage() { }


		public ExchangeObjectMoveKamaMessage InitExchangeObjectMoveKamaMessage(CustomVar<long> _quantity)
		{

			this.Quantity = _quantity;

			return this;
		}

		public  Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(Quantity);


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteData(this.Quantity);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.Quantity = reader.Read<CustomVar<long>>();

		}


	}
}
