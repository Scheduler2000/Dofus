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
	public class ExchangeBidHouseBuyMessage : IDofusMessage
	{
		public  const int NetworkId = 5804;
		public  int ProtocolId { get { return NetworkId; } }

		public CustomVar<int> Uid { get; set; }

		public CustomVar<int> Qty { get; set; }

		public CustomVar<long> Price { get; set; }


		public ExchangeBidHouseBuyMessage() { }


		public ExchangeBidHouseBuyMessage InitExchangeBidHouseBuyMessage(CustomVar<int> _uid, CustomVar<int> _qty, CustomVar<long> _price)
		{

			this.Uid = _uid;
			this.Qty = _qty;
			this.Price = _price;

			return this;
		}

		public  Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(Uid);
			size += DofusBinaryFactory.Sizing.SizeOf(Qty);
			size += DofusBinaryFactory.Sizing.SizeOf(Price);


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteData(this.Uid);
			writer.WriteData(this.Qty);
			writer.WriteData(this.Price);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.Uid = reader.Read<CustomVar<int>>();
			this.Qty = reader.Read<CustomVar<int>>();
			this.Price = reader.Read<CustomVar<long>>();

		}


	}
}
