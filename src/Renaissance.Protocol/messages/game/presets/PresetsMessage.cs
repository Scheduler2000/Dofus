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
using    Renaissance.Protocol.types.game.presets;

namespace Renaissance.Protocol.messages.game.presets
{
	public class PresetsMessage : IDofusMessage
	{
		public  const int NetworkId = 6750;
		public  int ProtocolId { get { return NetworkId; } }

		public Preset[] Presets { get; set; }


		public PresetsMessage() { }


		public PresetsMessage InitPresetsMessage(Preset[] _presets)
		{

			this.Presets = _presets;

			return this;
		}

		public  Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf((short)(this.Presets.Length));
			var memory1 = new Memory<byte>[Presets.Length];
			for(int i = 0; i < Presets.Length; i++)
			{
				size += DofusBinaryFactory.Sizing.SizeOf((short)(this.Presets[i].ProtocolId));
				memory1[i] = this.Presets[i].Serialize();
				size += memory1[i].Length;
			}


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteData((short)(this.Presets.Length));
			for(int i = 0; i < memory1.Length; i++)
			{
				writer.WriteData((short)(Presets[i].ProtocolId));
				writer.WriteDatas(memory1[i]);
			}

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			int Presets_length = reader.Read<short>();
			this.Presets = new Preset[Presets_length];
			for(int i = 0; i < Presets_length; i++)
			{
			reader.Skip(2); // skip protocolManager.GetInstance(short)
				this.Presets[i] = new Preset();
				this.Presets[i].Deserialize(reader);
			}

		}


	}
}
