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

namespace Renaissance.Protocol.messages.game.look
{
	public class AccessoryPreviewErrorMessage : IDofusMessage
	{
		public  const int NetworkId = 6521;
		public  int ProtocolId { get { return NetworkId; } }

		public byte Error { get; set; }


		public AccessoryPreviewErrorMessage() { }


		public AccessoryPreviewErrorMessage InitAccessoryPreviewErrorMessage(byte _error)
		{

			this.Error = _error;

			return this;
		}

		public  Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(Error);


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteData(this.Error);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.Error = reader.Read<byte>();

		}


	}
}
