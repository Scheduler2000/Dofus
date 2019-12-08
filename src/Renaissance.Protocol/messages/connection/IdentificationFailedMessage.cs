//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 08/12/2019 12:50:41.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.messages.connection
{
	public class IdentificationFailedMessage : IDofusMessage
	{
		public  const int NetworkId = 20;
		public  int ProtocolId { get { return NetworkId; } }

		public byte Reason { get; set; }


		public IdentificationFailedMessage() { }


		public IdentificationFailedMessage InitIdentificationFailedMessage(byte _reason)
		{

			this.Reason = _reason;

			return this;
		}

		public  Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(Reason);


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteData(this.Reason);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.Reason = reader.Read<byte>();

		}


	}
}
