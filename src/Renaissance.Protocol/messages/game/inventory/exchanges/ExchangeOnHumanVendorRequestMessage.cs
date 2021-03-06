//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 08/12/2019 12:50:52.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.messages.game.inventory.exchanges
{
	public class ExchangeOnHumanVendorRequestMessage : IDofusMessage
	{
		public  const int NetworkId = 5772;
		public  int ProtocolId { get { return NetworkId; } }

		public CustomVar<long> HumanVendorId { get; set; }

		public CustomVar<short> HumanVendorCell { get; set; }


		public ExchangeOnHumanVendorRequestMessage() { }


		public ExchangeOnHumanVendorRequestMessage InitExchangeOnHumanVendorRequestMessage(CustomVar<long> _humanvendorid, CustomVar<short> _humanvendorcell)
		{

			this.HumanVendorId = _humanvendorid;
			this.HumanVendorCell = _humanvendorcell;

			return this;
		}

		public  Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(HumanVendorId);
			size += DofusBinaryFactory.Sizing.SizeOf(HumanVendorCell);


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteData(this.HumanVendorId);
			writer.WriteData(this.HumanVendorCell);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.HumanVendorId = reader.Read<CustomVar<long>>();
			this.HumanVendorCell = reader.Read<CustomVar<short>>();

		}


	}
}
