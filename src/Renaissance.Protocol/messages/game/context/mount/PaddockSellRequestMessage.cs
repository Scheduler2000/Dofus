//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:18.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.messages.game.context.mount
{
	public class PaddockSellRequestMessage : IDofusMessage
	{
		public  const int NetworkId = 5953;
		public  int ProtocolId { get { return NetworkId; } }

		public CustomVar<long> Price { get; set; }

		public bool ForSale { get; set; }


		public PaddockSellRequestMessage() { }


		public PaddockSellRequestMessage InitPaddockSellRequestMessage(CustomVar<long> _price, bool _forsale)
		{

			this.Price = _price;
			this.ForSale = _forsale;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(this.Price);
			writer.Write(this.ForSale);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.Price = reader.Read<CustomVar<long>>();
			this.ForSale = reader.Read<bool>();

		}


	}
}