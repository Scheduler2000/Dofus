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
	public class ExchangeCraftCountRequestMessage : IDofusMessage
	{
		public  const int NetworkId = 6597;
		public  int ProtocolId { get { return NetworkId; } }

		public CustomVar<int> Count { get; set; }


		public ExchangeCraftCountRequestMessage() { }


		public ExchangeCraftCountRequestMessage InitExchangeCraftCountRequestMessage(CustomVar<int> _count)
		{

			this.Count = _count;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(this.Count);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.Count = reader.Read<CustomVar<int>>();

		}


	}
}
