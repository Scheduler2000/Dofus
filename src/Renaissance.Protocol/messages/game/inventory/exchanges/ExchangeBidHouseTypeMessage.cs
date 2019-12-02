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
	public class ExchangeBidHouseTypeMessage : IDofusMessage
	{
		public  const int NetworkId = 5803;
		public  int ProtocolId { get { return NetworkId; } }

		public CustomVar<int> Type { get; set; }

		public bool Follow { get; set; }


		public ExchangeBidHouseTypeMessage() { }


		public ExchangeBidHouseTypeMessage InitExchangeBidHouseTypeMessage(CustomVar<int> _type, bool _follow)
		{

			this.Type = _type;
			this.Follow = _follow;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(this.Type);
			writer.Write(this.Follow);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.Type = reader.Read<CustomVar<int>>();
			this.Follow = reader.Read<bool>();

		}


	}
}