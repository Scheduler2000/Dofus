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

		public  Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(Type);
			size += DofusBinaryFactory.Sizing.SizeOf(Follow);


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteData(this.Type);
			writer.WriteData(this.Follow);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.Type = reader.Read<CustomVar<int>>();
			this.Follow = reader.Read<bool>();

		}


	}
}
