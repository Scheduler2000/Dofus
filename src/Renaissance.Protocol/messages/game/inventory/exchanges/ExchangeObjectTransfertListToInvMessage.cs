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
	public class ExchangeObjectTransfertListToInvMessage : IDofusMessage
	{
		public  const int NetworkId = 6039;
		public  int ProtocolId { get { return NetworkId; } }

		public CustomVar<int>[] Ids { get; set; }


		public ExchangeObjectTransfertListToInvMessage() { }


		public ExchangeObjectTransfertListToInvMessage InitExchangeObjectTransfertListToInvMessage(CustomVar<int>[] _ids)
		{

			this.Ids = _ids;

			return this;
		}

		public  Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf((short)(this.Ids.Length));
			size += DofusBinaryFactory.Sizing.SizeOf(Ids);


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteData((short)(this.Ids.Length));
			writer.WriteDatas(Ids);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			int Ids_length = reader.Read<short>();
			this.Ids = new CustomVar<int>[Ids_length];
			for(int i = 0; i < Ids_length; i++)
				this.Ids[i] = reader.Read<CustomVar<int>>();

		}


	}
}
