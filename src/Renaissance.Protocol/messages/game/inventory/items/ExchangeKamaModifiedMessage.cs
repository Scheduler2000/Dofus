//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:22.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    Renaissance.Binary;
using    Renaissance.Binary.Definition;
using    Renaissance.Protocol.messages.game.inventory.exchanges;

namespace Renaissance.Protocol.messages.game.inventory.items
{
	public class ExchangeKamaModifiedMessage : ExchangeObjectMessage, IDofusMessage
	{
		public new const int NetworkId = 5521;
		public new int ProtocolId { get { return NetworkId; } }

		public CustomVar<long> Quantity { get; set; }


		public ExchangeKamaModifiedMessage() { }


		public ExchangeKamaModifiedMessage InitExchangeKamaModifiedMessage(CustomVar<long> _quantity)
		{

			this.Quantity = _quantity;

			return this;
		}

		public new byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(base.Serialize());
			writer.Write(this.Quantity);

			return writer.Data;
		}

		public new void Deserialize(DofusReader reader)
		{

			base.Deserialize(reader);
			this.Quantity = reader.Read<CustomVar<long>>();

		}


	}
}
