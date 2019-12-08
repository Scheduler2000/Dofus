//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 08/12/2019 12:50:46.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.messages.game.presets
{
	public class PresetDeleteRequestMessage : IDofusMessage
	{
		public  const int NetworkId = 6755;
		public  int ProtocolId { get { return NetworkId; } }

		public short PresetId { get; set; }


		public PresetDeleteRequestMessage() { }


		public PresetDeleteRequestMessage InitPresetDeleteRequestMessage(short _presetid)
		{

			this.PresetId = _presetid;

			return this;
		}

		public  Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(PresetId);


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteData(this.PresetId);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.PresetId = reader.Read<short>();

		}


	}
}
