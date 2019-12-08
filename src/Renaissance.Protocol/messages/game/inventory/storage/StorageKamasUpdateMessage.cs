//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 08/12/2019 12:50:53.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.messages.game.inventory.storage
{
	public class StorageKamasUpdateMessage : IDofusMessage
	{
		public  const int NetworkId = 5645;
		public  int ProtocolId { get { return NetworkId; } }

		public CustomVar<long> KamasTotal { get; set; }


		public StorageKamasUpdateMessage() { }


		public StorageKamasUpdateMessage InitStorageKamasUpdateMessage(CustomVar<long> _kamastotal)
		{

			this.KamasTotal = _kamastotal;

			return this;
		}

		public  Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(KamasTotal);


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteData(this.KamasTotal);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.KamasTotal = reader.Read<CustomVar<long>>();

		}


	}
}
