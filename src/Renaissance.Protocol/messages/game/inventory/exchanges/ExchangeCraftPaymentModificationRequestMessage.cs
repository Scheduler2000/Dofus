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

namespace Renaissance.Protocol.messages.game.inventory.exchanges
{
	public class ExchangeCraftPaymentModificationRequestMessage : IDofusMessage
	{
		public  const int NetworkId = 6579;
		public  int ProtocolId { get { return NetworkId; } }

		public CustomVar<long> Quantity { get; set; }


		public ExchangeCraftPaymentModificationRequestMessage() { }


		public ExchangeCraftPaymentModificationRequestMessage InitExchangeCraftPaymentModificationRequestMessage(CustomVar<long> _quantity)
		{

			this.Quantity = _quantity;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(this.Quantity);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.Quantity = reader.Read<CustomVar<long>>();

		}


	}
}
