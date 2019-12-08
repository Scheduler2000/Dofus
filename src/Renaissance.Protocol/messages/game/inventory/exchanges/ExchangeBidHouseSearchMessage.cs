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
	public class ExchangeBidHouseSearchMessage : IDofusMessage
	{
		public  const int NetworkId = 5806;
		public  int ProtocolId { get { return NetworkId; } }

		public CustomVar<short> GenId { get; set; }

		public bool Follow { get; set; }


		public ExchangeBidHouseSearchMessage() { }


		public ExchangeBidHouseSearchMessage InitExchangeBidHouseSearchMessage(CustomVar<short> _genid, bool _follow)
		{

			this.GenId = _genid;
			this.Follow = _follow;

			return this;
		}

		public  Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(GenId);
			size += DofusBinaryFactory.Sizing.SizeOf(Follow);


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteData(this.GenId);
			writer.WriteData(this.Follow);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.GenId = reader.Read<CustomVar<short>>();
			this.Follow = reader.Read<bool>();

		}


	}
}
