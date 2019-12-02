//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:28.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.types.game.mount
{
	public class UpdateMountBooleanCharacteristic : UpdateMountCharacteristic, IDofusType
	{
		public new const int NetworkId = 538;
		public new int ProtocolId { get { return NetworkId; } }

		public bool Value { get; set; }


		public UpdateMountBooleanCharacteristic() { }


		public UpdateMountBooleanCharacteristic InitUpdateMountBooleanCharacteristic(bool _value)
		{

			this.Value = _value;

			return this;
		}

		public new byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(base.Serialize());
			writer.Write(this.Value);

			return writer.Data;
		}

		public new void Deserialize(DofusReader reader)
		{

			base.Deserialize(reader);
			this.Value = reader.Read<bool>();

		}


	}
}