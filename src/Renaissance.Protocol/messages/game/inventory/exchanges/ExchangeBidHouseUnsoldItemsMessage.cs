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
using    Renaissance.Protocol.types.game.data.items;

namespace Renaissance.Protocol.messages.game.inventory.exchanges
{
	public class ExchangeBidHouseUnsoldItemsMessage : IDofusMessage
	{
		public  const int NetworkId = 6612;
		public  int ProtocolId { get { return NetworkId; } }

		public ObjectItemGenericQuantity[] Items { get; set; }


		public ExchangeBidHouseUnsoldItemsMessage() { }


		public ExchangeBidHouseUnsoldItemsMessage InitExchangeBidHouseUnsoldItemsMessage(ObjectItemGenericQuantity[] _items)
		{

			this.Items = _items;

			return this;
		}

		public  Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf((short)(this.Items.Length));
			var memory1 = new Memory<byte>[Items.Length];
			for(int i = 0; i < Items.Length; i++)
			{
				memory1[i] = this.Items[i].Serialize();
				size += memory1[i].Length;
			}


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteData((short)(this.Items.Length));
			for(int i = 0; i < memory1.Length; i++)
			{
				writer.WriteDatas(memory1[i]);
			}

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			int Items_length = reader.Read<short>();
			this.Items = new ObjectItemGenericQuantity[Items_length];
			for(int i = 0; i < Items_length; i++)
			{
				this.Items[i] = new ObjectItemGenericQuantity();
				this.Items[i].Deserialize(reader);
			}

		}


	}
}
