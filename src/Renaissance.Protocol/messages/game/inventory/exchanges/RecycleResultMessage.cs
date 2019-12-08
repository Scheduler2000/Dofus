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
	public class RecycleResultMessage : IDofusMessage
	{
		public  const int NetworkId = 6601;
		public  int ProtocolId { get { return NetworkId; } }

		public CustomVar<int> NuggetsForPrism { get; set; }

		public CustomVar<int> NuggetsForPlayer { get; set; }


		public RecycleResultMessage() { }


		public RecycleResultMessage InitRecycleResultMessage(CustomVar<int> _nuggetsforprism, CustomVar<int> _nuggetsforplayer)
		{

			this.NuggetsForPrism = _nuggetsforprism;
			this.NuggetsForPlayer = _nuggetsforplayer;

			return this;
		}

		public  Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(NuggetsForPrism);
			size += DofusBinaryFactory.Sizing.SizeOf(NuggetsForPlayer);


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteData(this.NuggetsForPrism);
			writer.WriteData(this.NuggetsForPlayer);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.NuggetsForPrism = reader.Read<CustomVar<int>>();
			this.NuggetsForPlayer = reader.Read<CustomVar<int>>();

		}


	}
}
