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

namespace Renaissance.Protocol.messages.game.presets
{
	public class PresetUseResultWithMissingIdsMessage : PresetUseResultMessage, IDofusMessage
	{
		public new const int NetworkId = 6757;
		public new int ProtocolId { get { return NetworkId; } }

		public CustomVar<short>[] MissingIds { get; set; }


		public PresetUseResultWithMissingIdsMessage() { }


		public PresetUseResultWithMissingIdsMessage InitPresetUseResultWithMissingIdsMessage(CustomVar<short>[] _missingids)
		{

			this.MissingIds = _missingids;

			return this;
		}

		public new byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(base.Serialize());
			writer.Write((short)(this.MissingIds.Length));
			foreach(var item in MissingIds)
				writer.Write(item);

			return writer.Data;
		}

		public new void Deserialize(DofusReader reader)
		{

			base.Deserialize(reader);
			int MissingIds_length = reader.Read<short>();
			this.MissingIds = new CustomVar<short>[MissingIds_length];
			for(int i = 0; i < MissingIds_length; i++)
				this.MissingIds[i] = reader.Read<CustomVar<short>>();

		}


	}
}