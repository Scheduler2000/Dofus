//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 08/12/2019 12:50:43.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.messages.game.basic
{
	public class SequenceNumberMessage : IDofusMessage
	{
		public  const int NetworkId = 6317;
		public  int ProtocolId { get { return NetworkId; } }

		public short Number { get; set; }


		public SequenceNumberMessage() { }


		public SequenceNumberMessage InitSequenceNumberMessage(short _number)
		{

			this.Number = _number;

			return this;
		}

		public  Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(Number);


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteData(this.Number);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.Number = reader.Read<short>();

		}


	}
}
