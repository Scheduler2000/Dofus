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
	public class ExchangeBidPriceForSellerMessage : ExchangeBidPriceMessage, IDofusMessage
	{
		public new const int NetworkId = 6464;
		public new int ProtocolId { get { return NetworkId; } }

		public bool AllIdentical { get; set; }

		public CustomVar<long>[] MinimalPrices { get; set; }


		public ExchangeBidPriceForSellerMessage() { }


		public ExchangeBidPriceForSellerMessage InitExchangeBidPriceForSellerMessage(bool _allidentical, CustomVar<long>[] _minimalprices)
		{

			this.AllIdentical = _allidentical;
			this.MinimalPrices = _minimalprices;

			return this;
		}

		public new byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(base.Serialize());
			writer.Write(this.AllIdentical);
			writer.Write((short)(this.MinimalPrices.Length));
			foreach(var item in MinimalPrices)
				writer.Write(item);

			return writer.Data;
		}

		public new void Deserialize(DofusReader reader)
		{

			base.Deserialize(reader);
			this.AllIdentical = reader.Read<bool>();
			int MinimalPrices_length = reader.Read<short>();
			this.MinimalPrices = new CustomVar<long>[MinimalPrices_length];
			for(int i = 0; i < MinimalPrices_length; i++)
				this.MinimalPrices[i] = reader.Read<CustomVar<long>>();

		}


	}
}