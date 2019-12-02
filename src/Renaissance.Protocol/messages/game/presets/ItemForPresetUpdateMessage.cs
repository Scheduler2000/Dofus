//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:13.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    Renaissance.Binary;
using    Renaissance.Binary.Definition;
using    Renaissance.Protocol.types.game.presets;

namespace Renaissance.Protocol.messages.game.presets
{
	public class ItemForPresetUpdateMessage : IDofusMessage
	{
		public  const int NetworkId = 6760;
		public  int ProtocolId { get { return NetworkId; } }

		public short PresetId { get; set; }

		public ItemForPreset PresetItem { get; set; }


		public ItemForPresetUpdateMessage() { }


		public ItemForPresetUpdateMessage InitItemForPresetUpdateMessage(short _presetid, ItemForPreset _presetitem)
		{

			this.PresetId = _presetid;
			this.PresetItem = _presetitem;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(this.PresetId);
			writer.Write(this.PresetItem.Serialize());

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.PresetId = reader.Read<short>();
			this.PresetItem = new ItemForPreset();
			this.PresetItem.Deserialize(reader);

		}


	}
}