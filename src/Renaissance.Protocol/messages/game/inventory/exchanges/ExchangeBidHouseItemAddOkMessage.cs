//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:20.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    Renaissance.Binary;
using    Renaissance.Binary.Definition;
using    Renaissance.Protocol.types.game.data.items;

namespace Renaissance.Protocol.messages.game.inventory.exchanges
{
	public class ExchangeBidHouseItemAddOkMessage : IDofusMessage
	{
		public  const int NetworkId = 5945;
		public  int ProtocolId { get { return NetworkId; } }

		public ObjectItemToSellInBid ItemInfo { get; set; }


		public ExchangeBidHouseItemAddOkMessage() { }


		public ExchangeBidHouseItemAddOkMessage InitExchangeBidHouseItemAddOkMessage(ObjectItemToSellInBid _iteminfo)
		{

			this.ItemInfo = _iteminfo;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(this.ItemInfo.Serialize());

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.ItemInfo = new ObjectItemToSellInBid();
			this.ItemInfo.Deserialize(reader);

		}


	}
}
