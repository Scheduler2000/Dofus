//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 08/12/2019 12:50:56.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.messages.game.context.roleplay.treasureHunt
{
	public class TreasureHuntShowLegendaryUIMessage : IDofusMessage
	{
		public  const int NetworkId = 6498;
		public  int ProtocolId { get { return NetworkId; } }

		public CustomVar<short>[] AvailableLegendaryIds { get; set; }


		public TreasureHuntShowLegendaryUIMessage() { }


		public TreasureHuntShowLegendaryUIMessage InitTreasureHuntShowLegendaryUIMessage(CustomVar<short>[] _availablelegendaryids)
		{

			this.AvailableLegendaryIds = _availablelegendaryids;

			return this;
		}

		public  Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf((short)(this.AvailableLegendaryIds.Length));
			size += DofusBinaryFactory.Sizing.SizeOf(AvailableLegendaryIds);


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteData((short)(this.AvailableLegendaryIds.Length));
			writer.WriteDatas(AvailableLegendaryIds);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			int AvailableLegendaryIds_length = reader.Read<short>();
			this.AvailableLegendaryIds = new CustomVar<short>[AvailableLegendaryIds_length];
			for(int i = 0; i < AvailableLegendaryIds_length; i++)
				this.AvailableLegendaryIds[i] = reader.Read<CustomVar<short>>();

		}


	}
}
